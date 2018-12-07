using AdlumenMVC.WebUI.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdlumenMVC.WebUI.Controllers
{
    public class UploadFilesController : Controller
    {
        //
        // GET: /UploadFiles/


        [ClaimsAuthorization(Modulo = "Documentos", ActionName = "RegistrarDocumentos")]
        [HttpPost]
        public JsonResult SaveFiles(string description)
        {
            string Message, fileName, actualFileName, fullFilePath;
            Message = fileName = actualFileName = fullFilePath = string.Empty;
            bool flag = false;
            string serverDefaultPath = "/app/UploadedFiles";
            string serverFilePath = string.Empty;
            if (Request.Form["pathtosave"] != null) serverDefaultPath = serverDefaultPath + Request.Form["pathtosave"];
            if (Request.Files != null)
            {
                var file = Request.Files[0];
                actualFileName = file.FileName;
                fileName = Path.GetFileNameWithoutExtension(file.FileName) + DateTime.Now.Ticks.ToString() + Path.GetExtension(file.FileName);
                int size = file.ContentLength;

                try
                {
                    bool exists = Directory.Exists(Server.MapPath("~" + serverDefaultPath));
                    if (!exists) Directory.CreateDirectory(Server.MapPath("~" + serverDefaultPath));
                    fullFilePath = Path.Combine(Server.MapPath("~"+serverDefaultPath), fileName);
                    file.SaveAs(fullFilePath);
                    serverFilePath = serverDefaultPath + "/" + fileName;
                    Message = "File uploaded successfully";
                    flag = true;
                }
                catch (Exception x)
                {
                    Message = "File upload failed! Please try again.";
                }

            }
            return new JsonResult { Data = new { Message = Message, Status = flag, FullFilePath = serverFilePath } };
        }
    }
}
