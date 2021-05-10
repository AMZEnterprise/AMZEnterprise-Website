using AMZEnterpriseWebsite.Core.Domain;

namespace AMZEnterpriseWebsite.Models.ViewModels
{
    public class PostCategoryViewModel : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int PostsCount { get; set; }
    }
}
