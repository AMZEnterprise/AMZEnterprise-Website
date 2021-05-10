using AMZEnterpriseWebsite.Areas.Panel.Models.ViewModels;
using AMZEnterpriseWebsite.Core.Domain;
using AutoMapper;

namespace AMZEnterpriseWebsite.Mappings.Resolvers
{
    /// <summary>
    /// Auto mapper resolver for PostFormViewModel UserFullName
    /// </summary>
    public class PostFormUserFullNameResolver : IValueResolver<Post, PostFormViewModel, string>
    {
        public string Resolve(Post source, PostFormViewModel destination, string destMember, ResolutionContext context)
        {
            return source.User?.FirstName + " " + source.User?.LastName;
        }
    }
}
