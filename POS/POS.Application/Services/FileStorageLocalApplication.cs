using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using POS.Application.Interfaces;
using POS.Infrastructure.FileStorage;

namespace POS.Application.Services
{
    public class FileStorageLocalApplication : IFileStorageLocalApplication
    {
        /// <summary>
        /// Proporciona información sobre todo el entorno de la applicación web
        /// </summary>
        private readonly IWebHostEnvironment _env;

        /// <summary>
        /// Detalles sobre la solicitud
        /// </summary>
        private readonly IHttpContextAccessor _contextAccessor;

        private readonly IFileStorageLocal _fileStorageLocal;
        public FileStorageLocalApplication(IWebHostEnvironment env, IHttpContextAccessor contextAccessor, IFileStorageLocal fileStorageLocal)
        {
            _env = env;
            _contextAccessor = contextAccessor;
            _fileStorageLocal = fileStorageLocal;
        }

        public async Task<string> SaveFile(string container, IFormFile file)
        {
            var webRootPath = _env.WebRootPath;
            var scheme = _contextAccessor.HttpContext!.Request.Scheme;
            var host = _contextAccessor.HttpContext!.Request.Host;

            return await _fileStorageLocal.SaveFile(container, file, webRootPath, scheme, host.Value);
        
        }

        public async Task<string> EditFile(string container, IFormFile file, string route)
        {
            var webRootPath = _env.WebRootPath;
            var scheme = _contextAccessor.HttpContext!.Request.Scheme;
            var host = _contextAccessor.HttpContext!.Request.Host;

            return await _fileStorageLocal.EditFile(container, file,route ,webRootPath, scheme, host.Value);
        }

        public async Task RemoveFile(string route, string container)
        {
            var webRootPath = _env.WebRootPath;
            await _fileStorageLocal.RemoveFile(route,container, webRootPath);
        }

        
    }
}
