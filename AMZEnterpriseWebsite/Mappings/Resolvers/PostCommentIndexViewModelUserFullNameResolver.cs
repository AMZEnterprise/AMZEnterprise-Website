using AMZEnterpriseWebsite.Areas.Panel.Models.ViewModels;
using AMZEnterpriseWebsite.Core.Domain;
using AutoMapper;

namespace AMZEnterpriseWebsite.Mappings.Resolvers
{
    /// <summary>
    /// Auto mapper resolver for PostCommentIndexViewModel UserFullName
    /// </summary>
    public class PostCommentIndexViewModelUserFullNameResolver : IValueResolver<PostComment, PostCommentIndexViewModel, string>
    {
        public string Resolve(PostComment source, PostCommentIndexViewModel destination, string destMember, ResolutionContext context)
        {
            return source.User == null ? source.UserFullName : source.User.FirstName + " " + source.User.LastName;
        }
    }
}
