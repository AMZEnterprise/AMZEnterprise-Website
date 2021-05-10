using AMZEnterpriseWebsite.Core.Domain;
using AMZEnterpriseWebsite.Models.ViewModels;
using AMZEnterpriseWebsite.Services.FileHandler;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;

namespace AMZEnterpriseWebsite.Mappings.Resolvers.WebsiteFrontResolvers
{
    /// <summary>
    /// Auto mapper resolver for PostViewModel FilePath
    /// </summary>
    public class PostViewModelFilePathResolver : IValueResolver<Post, PostViewModel, string>
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IFileHandler _fileHandler;

        public PostViewModelFilePathResolver(IWebHostEnvironment webHostEnvironment, IFileHandler fileHandler)
        {
            _webHostEnvironment = webHostEnvironment;
            _fileHandler = fileHandler;
        }
        public string Resolve(Post source, PostViewModel destination, string destMember, ResolutionContext context)
        {
            return _fileHandler.GetFileSource(
                _webHostEnvironment.WebRootPath,
                source.FilesPathGuid.ToString(),
                FileHandlerFolder.Posts);
        }
    }
}
