using AMZEnterpriseWebsite.Areas.Panel.Models.ViewModels;
using AMZEnterpriseWebsite.Core.Domain;
using AMZEnterpriseWebsite.Services.FileHandler;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;

namespace AMZEnterpriseWebsite.Mappings.Resolvers
{
    /// <summary>
    /// Auto mapper resolver for PostFormViewModel FilePath
    /// </summary>
    public class PostFormViewModelFilePathResolver : IValueResolver<Post, PostFormViewModel, string>
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IFileHandler _fileHandler;

        public PostFormViewModelFilePathResolver(IWebHostEnvironment webHostEnvironment, IFileHandler fileHandler)
        {
            _webHostEnvironment = webHostEnvironment;
            _fileHandler = fileHandler;
        }

        public string Resolve(Post source, PostFormViewModel destination, string destMember, ResolutionContext context)
        {
            return _fileHandler.GetFileSource(
                _webHostEnvironment.WebRootPath,
                source.FilesPathGuid.ToString(),
                FileHandlerFolder.Posts);
        }
    }
}
