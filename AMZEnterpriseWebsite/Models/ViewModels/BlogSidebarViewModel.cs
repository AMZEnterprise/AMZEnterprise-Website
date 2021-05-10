using System.Collections.Generic;

namespace AMZEnterpriseWebsite.Models.ViewModels
{
    public class BlogSidebarViewModel
    {
        public IEnumerable<PostViewModel> PostViewModels { get; set; }
        public IEnumerable<PostCategoryViewModel> PostCategoryViewModels { get; set; }
        public IEnumerable<string> PostTags { get; set; }
    }
}
