using System.Collections.Generic;

namespace AMZEnterpriseWebsite.Models.ViewModels
{
    public class PostsViewModel
    {
        public IEnumerable<PostViewModel> PostViewModels { get; set; }
        public Pager Pager { get; set; }
        public string SearchString { get; set; }
        public int? PostCategoryId { get; set; }
        public string PostTag { get; set; }
        public PostSortFilterType PostSortFilterType { get; set; }
    }
}
