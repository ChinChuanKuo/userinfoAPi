using System.Collections.Generic;
using System.Data;
using System.Net;
using userinfoApi.App_Code;

namespace userinfoApi.Models
{
    public class LoginClass
    {
        public userModels GetUserModels(userData userData, string cuurip)
        {
            switch (string.IsNullOrWhiteSpace(userData.userid))
            {
                case true:
                    return new userModels() { status = "errorUserid" };
            }
            database database = new database();
            DataTable userRows = new DataTable();
            List<dbparam> dbparamlist = new List<dbparam>();
            dbparamlist.Add(new dbparam("@userid", userData.userid.TrimEnd()));
            dbparamlist.Add(new dbparam("@status", "1"));
            userRows = database.checkSelectSql("mssql", "sysstring", "exec web.checksiteber @userid,@status;", dbparamlist);
            switch (userRows.Rows.Count)
            {
                case 0:
                    return new userModels() { status = "nodata" };
            }
            switch (userRows.Rows[0]["isused"].ToString().TrimEnd())
            {
                case "1":
                    return new userModels() { newid = userRows.Rows[0]["newid"].ToString().TrimEnd(), status = "istrue" };
            }
            return new userModels() { status = "islock" };
        }

        public loginModels GetLoginModels(loginData loginData, string cuurip, string userAgent)
        {
            switch (string.IsNullOrWhiteSpace(loginData.userid))
            {
                case true:
                    return new loginModels() { status = "errorUserid" };
            }
            switch (string.IsNullOrWhiteSpace(loginData.password))
            {
                case true:
                    return new loginModels() { status = "errorPassword" };
            }
            database database = new database();
            DataTable mainRows = new DataTable();
            List<dbparam> dbparamlist = new List<dbparam>();
            dbparamlist.Add(new dbparam("@userid", loginData.userid.TrimEnd()));
            dbparamlist.Add(new dbparam("@password", new sha256().encry256(loginData.password.TrimEnd())));
            dbparamlist.Add(new dbparam("@status", "1"));
            mainRows = database.checkSelectSql("mssql", "sysstring", "exec web.loginsiteber @userid,@password,@status;", dbparamlist);
            switch (mainRows.Rows.Count)
            {
                case 0:
                    return new loginModels() { status = "nodata" };
            }
            switch (mainRows.Rows[0]["isused"].ToString().TrimEnd())
            {
                case "1":
                    string longitude = string.IsNullOrWhiteSpace(loginData.longitude) ? "0.0" : loginData.longitude, latitude = string.IsNullOrWhiteSpace(loginData.latitude) ? "0.0" : loginData.latitude, cuname = Dns.GetHostEntry(cuurip).HostName.IndexOf('.') == -1 ? Dns.GetHostEntry(cuurip).HostName : Dns.GetHostEntry(cuurip).HostName.Split('.')[0];
                    information information = new information();
                    dbparamlist.Clear();
                    DataTable subRows = new DataTable();
                    dbparamlist.Add(new dbparam("@newid", mainRows.Rows[0]["newid"].ToString().TrimEnd()));
                    dbparamlist.Add(new dbparam("@externip", cuurip));
                    dbparamlist.Add(new dbparam("@longitude", longitude));
                    dbparamlist.Add(new dbparam("@latitude", latitude));
                    dbparamlist.Add(new dbparam("@hostname", cuname));
                    dbparamlist.Add(new dbparam("@browser", information.browser(userAgent)));
                    dbparamlist.Add(new dbparam("@os", information.osystem(userAgent)));
                    subRows = database.checkSelectSql("mssql", "sysstring", "exec web.checksitelog @userid,@password,@externip,@status;", dbparamlist);
                    switch (subRows.Rows.Count)
                    {
                        case 0:
                            return new loginModels() { newid = mainRows.Rows[0]["newid"].ToString().TrimEnd(), name = mainRows.Rows[0]["username"].ToString().TrimEnd().Substring(0, 1), allname = mainRows.Rows[0]["username"].ToString().TrimEnd(), status = "istrue" };
                    }
                    break;
            }
            return new loginModels() { status = "islock" };
        }
    }
}