using AMZEnterpriseWebsite.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AMZEnterpriseWebsite.ViewComponents
{
    public class CommentsViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(PostCommentTreeViewModel commentTree)
        {
            var articleCommentTree = new PostCommentTreeViewModel { CommentSeed = commentTree.CommentSeed, PostCommentViewModels = commentTree.PostCommentViewModels };

            return await Task.FromResult(View(articleCommentTree));
        }
    }
}
