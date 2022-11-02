using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        public static string Add(IFormFile file)
        {
            string path = Environment.CurrentDirectory + @"\ProjectMaterials";
            var sourcePath = Path.GetTempFileName();
            if (file.Length > 0)
            {
                using (var stream = new FileStream(sourcePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

            }
            var result = NewPath(file);
            File.Move(sourcePath, path + result);
            return result.Replace("\\", "/");

        }
        public static IResult Delete(string path)
        {
            string path2 = Environment.CurrentDirectory + @"\ProjectMaterials";
            path = path.Replace("/", "\\");
            try
            {
                File.Delete(path2 + path);
            }
            catch(Exception exception)
            {
                return new ErrorResult(exception.Message);
            }
            return new SuccessResult();
        }
        public static string Update(string sourcePath,IFormFile formFile)
        {
            string path = Environment.CurrentDirectory + @"\ProjectMaterials";
            var result = NewPath(formFile);
            if (sourcePath.Length > 0)
            {
                using(var stream =new FileStream(path + result, FileMode.Create))
                {
                    formFile.CopyTo(stream);
                }
            }
            File.Delete(path + sourcePath);
            return result.Replace("\\", "/");
        }
        public static string NewPath(IFormFile formFile)
        {
            FileInfo fileInfo = new FileInfo(formFile.FileName);
            string fileExtension = fileInfo.Extension;
            var newPath = Guid.NewGuid().ToString() + fileExtension;
            return @"\Images\" + newPath;
        }
    }
}
