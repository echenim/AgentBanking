using System;
using System.IO;
using System.Web;

namespace Echenim.Nine.Util.FileUtilities
{
    public class FileToDisk
    {
        public FileManagerUtil SaveFileToDisk(HttpPostedFileBase entityHttpPostedFileBase, string path, string generatedfileName)
        {
            var fileManagerutil = new FileManagerUtil();

            try
            {

                var extension = Path.GetExtension(entityHttpPostedFileBase.FileName);

                if (entityHttpPostedFileBase.ContentLength > 0)
                {
                    var pathToSave = System.Web.HttpContext.Current.Server.MapPath(path);
                    var imagePath = Path.Combine(pathToSave, $"{generatedfileName + extension}".ToLower());
                    entityHttpPostedFileBase.SaveAs(imagePath);

                    fileManagerutil.FileNameOnDisk = generatedfileName+extension;
                    fileManagerutil.Message = $" was succeesful ";
                    fileManagerutil.OnSucceed = true;
                }
                else
                {
                    fileManagerutil.Message = $"file with zero content";
                    fileManagerutil.OnSucceed = false;
                }

               
            }
            catch(Exception ex)
            {
                fileManagerutil.Message = $" an error occured : {ex.Message}";
                fileManagerutil.OnSucceed = false;
            }

            return fileManagerutil;
        }
        
    }


    public class FileManagerUtil
    {
        public string Message { get; set; }
        public string FileNameOnDisk { get; set; }
        public bool OnSucceed { get; set; }
    }


}
