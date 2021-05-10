using AMZEnterpriseWebsite.Core.Domain;
using AMZEnterpriseWebsite.Models.ViewModels;
using AMZEnterpriseWebsite.Services.FileHandler;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;

namespace AMZEnterpriseWebsite.Mappings.Resolvers.WebsiteFrontResolvers
{
    /// <summary>
    /// Auto mapper resolver for CertificateViewModel FilePath
    /// </summary>
    public class CertificateViewModelFilePathResolver : IValueResolver<Certificate, CertificateViewModel, string>
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IFileHandler _fileHandler;

        public CertificateViewModelFilePathResolver(IWebHostEnvironment webHostEnvironment, IFileHandler fileHandler)
        {
            _webHostEnvironment = webHostEnvironment;
            _fileHandler = fileHandler;
        }

        public string Resolve(Certificate source, CertificateViewModel destination, string destMember, ResolutionContext context)
        {
            return _fileHandler.GetFileSource(
                _webHostEnvironment.WebRootPath,
                source.FilesPathGuid.ToString(),
                FileHandlerFolder.Certificates);
        }
    }
}
