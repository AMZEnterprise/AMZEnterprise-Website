using AMZEnterpriseWebsite.Areas.Panel.Models.ViewModels;
using AMZEnterpriseWebsite.Core.Domain;
using AutoMapper;

namespace AMZEnterpriseWebsite.Mappings.Resolvers
{
    /// <summary>
    /// Auto mapper resolver for UserIndexViewModel UserFullName
    /// </summary>
    public class UserIndexViewModelUserFullNameResolver : IValueResolver<User, UserIndexViewModel, string>
    {
        public string Resolve(User source, UserIndexViewModel destination, string destMember, ResolutionContext context)
        {
            return source.FirstName + " " + source.LastName;
        }
    }
}
