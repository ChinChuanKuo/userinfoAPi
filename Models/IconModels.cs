using System.Collections.Generic;
using userinfoApi.App_Code;

namespace userinfoApi.Models
{
    public class IconClass
    {
        public statusModels GetSearchModels(userData userData, string cuurip)
        {
            /*database database = new database();
            DataTable mainRows = new DataTable();
            List<dbparam> dbparamlist = new List<dbparam>();
            mainRows = database.checkSelectSql("mssql", "sysstring", "select value,icon from web.qaitemform where inoper = @inoper;", dbparamlist);
            switch (mainRows.Rows.Count)
            {
                case 0:
                    return new sItemsModels() { status = "nodata" };
            }
            List<Dictionary<string, object>> items = new List<Dictionary<string, object>>();
            foreach (DataRow dr in mainRows.Rows)
            {
                items.Add(new Dictionary<string, object>() { { "icon", dr["icon"].ToString().TrimEnd() }, { "value", dr["value"].ToString().TrimEnd() } });
            }*/
            return new statusModels() { status = "istrue" };
        }

        public statusModels GetInsertModels(iIconData iIconData, string cuurip)
        {
            database database = new database();
            foreach (var item in iIconData.items)
            {
                List<dbparam> dbparamlist = new List<dbparam>();
                dbparamlist.Add(new dbparam("@value", item["value"].ToString().TrimEnd()));
                dbparamlist.Add(new dbparam("@icon", item["icon"].ToString().TrimEnd()));
                dbparamlist.Add(new dbparam("@inoper", iIconData.newid.TrimEnd()));
                if (database.checkActiveSql("mssql", "sysstring", "exec web.checkiconform @value,@icon,@inoper;", dbparamlist) != "istrue")
                {
                    return new statusModels() { status = "error" };
                }
            }
            foreach (var item in iIconData.qaitems)
            {
                List<dbparam> dbparamlist = new List<dbparam>();
                dbparamlist.Add(new dbparam("@padding", "0"));
                dbparamlist.Add(new dbparam("@value", item["value"].ToString().TrimEnd()));
                dbparamlist.Add(new dbparam("@icon", item["icon"].ToString().TrimEnd()));
                dbparamlist.Add(new dbparam("@inoper", iIconData.newid.TrimEnd()));
                if (database.checkActiveSql("mssql", "sysstring", "exec web.checkiconform @value,@padding,@icon,@inoper;", dbparamlist) != "istrue")
                {
                    return new statusModels() { status = "error" };
                }
            }
            return new statusModels() { status = "saveSuccess" };
        }
    }
}