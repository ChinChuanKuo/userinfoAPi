using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using userinfoApi.App_Code;
using Spire.Doc;
using Spire.Pdf;
using Spire.Xls;
using Spire.Presentation;

namespace userinfoApi.Models
{
    public class FilesClass
    {
        public sSiteModels GetWebsiteModels(sRowsData sRowsData, string cuurip, string userAgent)
        {
            database database = new database();
            DataTable mainRows = new DataTable();
            List<dbparam> dbparamlist = new List<dbparam>();
            dbparamlist.Add(new dbparam("@newid", sRowsData.newid.TrimEnd()));
            mainRows = database.checkSelectSql("mssql", "sysstring", "exec web.searchformber @newid;", dbparamlist);
            switch (mainRows.Rows.Count)
            {
                case 0:
                    return new sSiteModels() { status = "nodata" };
            }
            string sysFile = $"{database.connectionString("sysFiles")}\\{mainRows.Rows[0]["formId"].ToString().TrimEnd()}\\";
            Directory.CreateDirectory(sysFile);
            datetime datetime = new datetime();
            string stdate = datetime.sqldate("mssql", "sysstring"), sttime = datetime.sqltime("mssql", "sysstring"), cuname = Dns.GetHostEntry(cuurip).HostName.IndexOf('.') == -1 ? Dns.GetHostEntry(cuurip).HostName : Dns.GetHostEntry(cuurip).HostName.Split('.')[0], original = "", encryption = new sha256().new256("mssql", "sysstring"), extension = ".jpg";
            new WebClient().DownloadFile(sRowsData.value.TrimEnd(), $"{sysFile}{original}({encryption}){extension}");
            dbparamlist.Clear();
            dbparamlist.Add(new dbparam("@formId", mainRows.Rows[0]["formId"].ToString().TrimEnd()));
            dbparamlist.Add(new dbparam("@siteId", sRowsData.formId.TrimEnd()));
            dbparamlist.Add(new dbparam("@website", sRowsData.value.TrimEnd()));
            dbparamlist.Add(new dbparam("@externip", cuurip));
            dbparamlist.Add(new dbparam("@hostname", cuname));
            dbparamlist.Add(new dbparam("@browser", new information().browser(userAgent)));
            dbparamlist.Add(new dbparam("@stdate", stdate));
            dbparamlist.Add(new dbparam("@sttime", sttime));
            dbparamlist.Add(new dbparam("@inoper", sRowsData.newid.TrimEnd()));
            if (database.checkActiveSql("mssql", "sysstring", "exec web.insertwebsiteform @formId,@siteId,@website,@externip,@hostname,@browser,@stdate,@sttime,@inoper;", dbparamlist) != "istrue")
            {
                return new sSiteModels() { status = "error" };
            }
            switch (File.Exists($"{sysFile}{original}({encryption}){extension}"))
            {
                case false:
                    return new sSiteModels() { status = "nodata" };
            }
            return new sSiteModels() { images = true, videos = false, audios = false, src = $"{original}({encryption}){extension}", imagePath = $"{database.connectionString("sysHttps")}{mainRows.Rows[0]["formId"].ToString().TrimEnd()}/", original = original, encryption = encryption, extension = extension, status = "istrue" };
        }

        public statusModels GetDownloadModels(sRowsData sRowsData, string cuurip, string userAgent)
        {
            database database = new database();
            DataTable mainRows = new DataTable();
            List<dbparam> dbparamlist = new List<dbparam>();
            dbparamlist.Add(new dbparam("@newid", sRowsData.newid.TrimEnd()));
            mainRows = database.checkSelectSql("mssql", "sysstring", "exec web.searchformber @newid;", dbparamlist);
            switch (mainRows.Rows.Count)
            {
                case 0:
                    return new statusModels() { status = "nodata" };
            }
            datetime datetime = new datetime();
            string stdate = datetime.sqldate("mssql", "sysstring"), sttime = datetime.sqltime("mssql", "sysstring");
            switch (File.Exists($"{database.connectionString("sysFiles")}\\{mainRows.Rows[0]["formId"].ToString().TrimEnd()}\\{sRowsData.value.TrimEnd()}"))
            {
                case false:
                    return new statusModels() { status = "nodata" };
            }
            string cuname = Dns.GetHostEntry(cuurip).HostName.IndexOf('.') == -1 ? Dns.GetHostEntry(cuurip).HostName : Dns.GetHostEntry(cuurip).HostName.Split('.')[0];
            dbparamlist.Clear();
            dbparamlist.Add(new dbparam("@formId", mainRows.Rows[0]["formId"].ToString().TrimEnd()));
            dbparamlist.Add(new dbparam("@fileId", sRowsData.formId.TrimEnd()));
            dbparamlist.Add(new dbparam("@files", sRowsData.value.TrimEnd()));
            dbparamlist.Add(new dbparam("@externip", cuurip));
            dbparamlist.Add(new dbparam("@hostname", cuname));
            dbparamlist.Add(new dbparam("@browser", new information().browser(userAgent)));
            dbparamlist.Add(new dbparam("@stdate", stdate));
            dbparamlist.Add(new dbparam("@sttime", sttime));
            dbparamlist.Add(new dbparam("@inoper", sRowsData.newid.TrimEnd()));
            if (database.checkActiveSql("mssql", "sysstring", "exec web.insertdownloadform @formId,@fileId,@files,@externip,@hostname,@browser,@stdate,@sttime,@inoper;", dbparamlist) != "istrue")
            {
                return new statusModels() { status = "error" };
            }
            return new statusModels() { status = "istrue" };
        }

        [System.Obsolete]
        public sSiteModels GetTransferModels(sFileData sFileData, string cuurip)
        {
            database database = new database();
            DataTable mainRows = new DataTable();
            List<dbparam> dbparamlist = new List<dbparam>();
            dbparamlist.Add(new dbparam("@newid", sFileData.newid.TrimEnd()));
            mainRows = database.checkSelectSql("mssql", "sysstring", "exec web.searchformber @newid;", dbparamlist);
            switch (mainRows.Rows.Count)
            {
                case 0:
                    return new sSiteModels() { status = "nodata" };
            }
            string filePath = $"{database.connectionString("sysFiles")}\\{mainRows.Rows[0]["formId"].ToString().TrimEnd()}\\", encryption = new sha256().new256("mssql", "sysstring"), extension = "pdf";
            switch (File.Exists($"{filePath}{sFileData.original.TrimEnd()}({sFileData.encryption.TrimEnd()}){sFileData.extension.TrimEnd()}"))
            {
                case false:
                    return new sSiteModels() { status = "nodata" };
            }
            dbparamlist.Clear();
            DataTable subRows = new DataTable();
            dbparamlist.Add(new dbparam("@value", extension));
            dbparamlist.Add(new dbparam("@needed", "1"));
            subRows = database.checkSelectSql("mssql", "sysstring", "exec web.uploadfileform @value,@needed;", dbparamlist);
            switch (subRows.Rows.Count)
            {
                case 0:
                    return new sSiteModels() { status = "nodata" };
            }
            if (subRows.Rows[0]["flImages"].ToString().TrimEnd() == "0" && subRows.Rows[0]["flVideos"].ToString().TrimEnd() == "0" && subRows.Rows[0]["flAudios"].ToString().TrimEnd() == "0")
            {
                return new sSiteModels() { status = "nodata" };
            }
            switch (transFileToPDF(sFileData.extension.TrimEnd(), $"{filePath}{sFileData.original.TrimEnd()}({sFileData.encryption.TrimEnd()}){sFileData.extension.TrimEnd()}", $"{filePath}{sFileData.original.TrimEnd()}({encryption}).{extension}"))
            {
                case false:
                    return new sSiteModels() { status = "nodata" };
            }
            return new sSiteModels() { images = subRows.Rows[0]["flImages"].ToString().TrimEnd() == "1", videos = subRows.Rows[0]["flVideos"].ToString().TrimEnd() == "1", audios = subRows.Rows[0]["flAudios"].ToString().TrimEnd() == "1", src = subRows.Rows[0]["flImages"].ToString().TrimEnd() == "1" && subRows.Rows[0]["flShowed"].ToString().TrimEnd() == "0" ? $"{subRows.Rows[0]["original"].ToString().TrimEnd()}({subRows.Rows[0]["encryption"].ToString().TrimEnd()}){subRows.Rows[0]["extension"].ToString().TrimEnd()}" : $"{sFileData.original.TrimEnd()}({encryption}).{extension}", imagePath = $"{database.connectionString("sysHttps")}{mainRows.Rows[0]["formId"].ToString().TrimEnd()}/", original = sFileData.original.TrimEnd(), encryption = encryption, extension = $".{extension}", date = new datetime().sqldate("mssql", "sysstring"), status = "istrue" };
        }

        [System.Obsolete]
        public bool transFileToPDF(string extension, string originalPath, string savePath)
        {
            switch (extension)
            {
                case ".xls":
                case ".xlsx":
                    return transExcelToPDF(originalPath, savePath);
                case ".doc":
                case ".docx":
                    return transWordToPDF(originalPath, savePath);
                case ".ppt":
                case ".pptx":
                    return transPowerPointToPDF(originalPath, savePath);
                case ".xps":
                    return transXpsToPDF(originalPath, savePath);
            }
            return false;
        }

        public bool transExcelToPDF(string originalPath, string savePath)
        {
            Workbook workbook = new Workbook();
            workbook.LoadFromFile(originalPath, ExcelVersion.Version2010);
            workbook.SaveToFile(savePath, Spire.Xls.FileFormat.PDF);
            return File.Exists(savePath);
        }

        public bool transWordToPDF(string originalPath, string savePath)
        {
            Document document = new Document();
            document.LoadFromFile(originalPath);
            document.SaveToFile(savePath, Spire.Doc.FileFormat.PDF);
            return File.Exists(savePath);
        }

        public bool transPowerPointToPDF(string originalPath, string savePath)
        {
            Presentation presentation = new Presentation();
            presentation.LoadFromFile(originalPath);
            presentation.SaveToFile(savePath, Spire.Presentation.FileFormat.PDF);
            return File.Exists(savePath);
        }

        [System.Obsolete]
        public bool transXpsToPDF(string originalPath, string savePath)
        {
            PdfDocument document = new PdfDocument();
            document.UseHighQualityImage = true;
            document.LoadFromFile(originalPath, Spire.Pdf.FileFormat.XPS);
            document.SaveToFile(savePath, Spire.Pdf.FileFormat.PDF);
            return File.Exists(savePath);
        }

        public string GetFileType(string extension)
        {
            DataTable mainRows = new DataTable();
            List<dbparam> dbparamlist = new List<dbparam>();
            dbparamlist.Add(new dbparam("@value", extension.Replace(".", "").ToLower()));
            dbparamlist.Add(new dbparam("@needed", "1"));
            mainRows = new database().checkSelectSql("mssql", "sysstring", "exec web.searchfiletype @value,@needed;", dbparamlist);
            switch (mainRows.Rows.Count)
            {
                case 0:
                    return "OTHER";
            }
            return mainRows.Rows[0]["flTitle"].ToString().TrimEnd();
        }

        public long GetFileCapacity(string filePath, string filename)
        {
            return new System.IO.FileInfo(filePath + filename).Length;
        }
    }
}