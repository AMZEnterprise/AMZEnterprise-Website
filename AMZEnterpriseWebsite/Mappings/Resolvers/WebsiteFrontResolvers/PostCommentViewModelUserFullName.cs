using AMZEnterpriseWebsite.Core.Domain;
using AMZEnterpriseWebsite.Models.ViewModels;
using AutoMapper;

namespace AMZEnterpriseWebsite.Mappings.Resolvers.WebsiteFrontResolvers
{
    /// <summary>
    /// Auto mapper resolver for PostCommentViewModel UserFullName
    /// </summary>
    public class PostCommentViewModelUserFullName : IValueResolver<PostComment, PostCommentViewModel, string>
    {
        public string Resolve(PostComment source, PostCommentViewModel destination, string destMember, ResolutionContext context)
        {
            return source.User == null ? source.UserFullName : source.User.FirstName + " " + source.User.LastName;
        }
    }
}
