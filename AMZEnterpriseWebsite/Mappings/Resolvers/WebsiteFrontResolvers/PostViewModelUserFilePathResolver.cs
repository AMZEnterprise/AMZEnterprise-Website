using AMZEnterpriseWebsite.Core.Domain;
using AMZEnterpriseWebsite.Models.ViewModels;
using AMZEnterpriseWebsite.Services.FileHandler;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;

namespace AMZEnterpriseWebsite.Mappings.Resolvers.WebsiteFrontResolvers
{
    /// <summary>
    /// Auto mapper resolver for PostViewModel UserFilePath
    /// </summary>
    public class PostViewModelUserFilePathResolver : IValueResolver<Post, PostViewModel, string>
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IFileHandler _fileHandler;

        public PostViewModelUserFilePathResolver(IWebHostEnvironment webHostEnvironment, IFileHandler fileHandler)
        {
            _webHostEnvironment = webHostEnvironment;
            _fileHandler = fileHandler;
        }
        public string Resolve(Post source, PostViewModel destination, string destMember, ResolutionContext context)
        {
            return _fileHandler.GetFileSource(
                _webHostEnvironment.WebRootPath,
                source.User.FilesPathGuid.ToString(),
                FileHandlerFolder.Profiles);
        }
    }
}
