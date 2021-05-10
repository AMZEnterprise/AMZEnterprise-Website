using AMZEnterpriseWebsite.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AMZEnterpriseWebsite.ViewComponents
{
    public class BlogPostCardViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(PostViewModel postViewModel)
        {
            return View(postViewModel);
        }
    }
}
