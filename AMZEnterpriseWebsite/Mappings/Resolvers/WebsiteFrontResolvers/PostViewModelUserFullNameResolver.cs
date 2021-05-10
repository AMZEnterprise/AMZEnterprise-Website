using AMZEnterpriseWebsite.Core.Domain;
using AMZEnterpriseWebsite.Models.ViewModels;
using AutoMapper;

namespace AMZEnterpriseWebsite.Mappings.Resolvers.WebsiteFrontResolvers
{
    /// <summary>
    /// Auto mapper resolver for PostViewModel UserFullName
    /// </summary>
    public class PostViewModelUserFullNameResolver : IValueResolver<Post, PostViewModel, string>
    {
        public string Resolve(Post source, PostViewModel destination, string destMember, ResolutionContext context)
        {
            return source.User.FirstName + " " + source.User.LastName;
        }
    }
}
