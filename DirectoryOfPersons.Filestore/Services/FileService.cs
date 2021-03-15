using DirectoryOfPersons.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace DirectoryOfPersons.Filestore.Services
{
    public class FileService : IFileService
    {
        public string Upload(IFormFile file, string key)
        {
            var fullPath = GetFileFullPath(file, key);
            if (file.Length <= 0)
                throw new Exception("File has no length!");

            if (File.Exists(fullPath))
                throw new Exception("File already exists!");

            using var stream = new FileStream(fullPath, FileMode.Create);
            file.CopyTo(stream);
            return fullPath;
        }
        public void Delete(string fullPath)
        {
            if (File.Exists(fullPath))
                File.Delete(fullPath);
        }

        private string GetFileFullPath(IFormFile file, string key)
        {
            var projectPath = Path.GetDirectoryName(Environment.CurrentDirectory);
            var filestorePath = $"{projectPath}\\DirectoryOfPersons.Filestore\\Storage";
            var fullPath = $"{filestorePath}\\{key}-{file.FileName}";
            return fullPath;
        }
    }
}
