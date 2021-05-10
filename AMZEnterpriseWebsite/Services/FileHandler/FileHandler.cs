using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace AMZEnterpriseWebsite.Services.FileHandler
{
    /// <summary>
    /// Default implementation for IFileHandler.
    /// </summary>
    public class FileHandler : IFileHandler
    {
        //Static path values
        private static class ConstantPath
        {
            public const string Posts = "posts";
            public const string Profiles = "profiles";
            public const string Certificates = "certificates";
            public const string Uploads = "uploads";
        }

        private string GetUploadFolderPath(FileHandlerFolder fileHandlerFolder)
        {
            if (fileHandlerFolder == FileHandlerFolder.Posts)
                return ConstantPath.Posts;

            if (fileHandlerFolder == FileHandlerFolder.Profiles)
                return ConstantPath.Profiles;

            if (fileHandlerFolder == FileHandlerFolder.Certificates)
                return ConstantPath.Certificates;

            return string.Empty;
        }
        private async Task Upload(IFormFile file, string uploadPath)
        {
            Directory.CreateDirectory(uploadPath);

            var fullPath = Path.Combine(uploadPath, file.FileName);

            try
            {
                using (var fs = new FileStream(fullPath, FileMode.Create))
                {
                    await file.CopyToAsync(fs);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task UploadMedia(
            IFormFileCollection files,
            string webRootPath,
            string filePath, 
            FileHandlerFolder fileHandlerFolder)
        {
            string uploadPath = webRootPath + "\\" + ConstantPath.Uploads + "\\"
                                + GetUploadFolderPath(fileHandlerFolder) + "\\" + filePath;
            foreach (var file in files)
            {
                await Upload(file, uploadPath);
            }
        }

        public void DeleteMedia(string webRootPath, string filePath, FileHandlerFolder fileHandlerFolder)
        {
            string uploadPath = webRootPath + "\\" + ConstantPath.Uploads + "\\"
                                + GetUploadFolderPath(fileHandlerFolder) + "\\" + filePath;
            try
            {
                if (Directory.Exists(uploadPath))
                {
                    Directory.Delete(uploadPath, true);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string GetFileSource(string webRootPath, string filePath, FileHandlerFolder fileHandlerFolder)
        {
            var folderPath = GetUploadFolderPath(fileHandlerFolder);
            string uploadPath = webRootPath + "\\" + ConstantPath.Uploads + "\\"
                                + folderPath + "\\" + filePath;

            try
            {
                var files = Directory.GetFiles(
                    uploadPath,
                    "*.*",
                    SearchOption.TopDirectoryOnly);

                if (files.Length > 0 && files[0] != null)
                {
                    var path = "\\" + ConstantPath.Uploads + "\\" + 
                               folderPath + "\\" + filePath + "\\" + Path.GetFileName(files[0]);

                    return path.Replace(@"\", "/");
                }
            }
            catch { }

            return null;
        }
    }

}
