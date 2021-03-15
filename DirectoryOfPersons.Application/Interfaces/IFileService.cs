using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace DirectoryOfPersons.Application.Interfaces
{
    public interface IFileService
    {
        string Upload(IFormFile file, string key);
        void Delete(string filePath);
    }
}
