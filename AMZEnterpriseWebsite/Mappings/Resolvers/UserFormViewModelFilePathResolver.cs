using AMZEnterpriseWebsite.Areas.Panel.Models.ViewModels;
using AMZEnterpriseWebsite.Core.Domain;
using AMZEnterpriseWebsite.Services.FileHandler;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;

namespace AMZEnterpriseWebsite.Mappings.Resolvers
{
    /// <summary>
    /// Auto mapper resolver for UserFormViewModel FilePath
    /// </summary>
    public class UserFormViewModelFilePathResolver : IValueResolver<User, UserFormViewModel, string>
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IFileHandler _fileHandler;

        public UserFormViewModelFilePathResolver(IWebHostEnvironment webHostEnvironment, IFileHandler fileHandler)
        {
            _webHostEnvironment = webHostEnvironment;
            _fileHandler = fileHandler;
        }
        public string Resolve(User source, UserFormViewModel destination, string destMember, ResolutionContext context)
        {
            return _fileHandler.GetFileSource(
                _webHostEnvironment.WebRootPath,
                source.FilesPathGuid.ToString(),
                FileHandlerFolder.Profiles);
        }
    }
}
