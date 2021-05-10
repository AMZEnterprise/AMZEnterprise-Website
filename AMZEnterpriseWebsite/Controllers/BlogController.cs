using AMZEnterpriseWebsite.Core.Domain;
using AMZEnterpriseWebsite.Infrastructure;
using AMZEnterpriseWebsite.Models;
using AMZEnterpriseWebsite.Models.Constants;
using AMZEnterpriseWebsite.Models.ViewModels;
using AMZEnterpriseWebsite.Persistence;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMZEnterpriseWebsite.Controllers
{
    public class BlogController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _accessor;

        public BlogController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IHttpContextAccessor accessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _accessor = accessor;
        }

        [Breadcrumb("وبلاگ")]
        public IActionResult Index(
            int? page, string searchString, int? postCategoryId, string postTag, PostSortFilterType postSortFilterType = PostSortFilterType.SortByDateDesc)
        {
            var postSearch = new PostSearch()
            {
                SearchString = searchString,
                PostCategoryId = postCategoryId,
                PostTag = postTag,
                PostSortFilterType = postSortFilterType,
            };

            int pageSize = 6;

            var posts = GetPosts(postSearch, pageIndex: page - 1 ?? 0, pageSize: pageSize);

            var blogViewModel = new PostsViewModel()
            {
                PostViewModels = _mapper.Map<IEnumerable<Post>, IEnumerable<PostViewModel>>(posts),
                Pager = new Pager(posts.TotalCount, posts.TotalPages, page, pageSize),
                SearchString = searchString,
                PostCategoryId = postCategoryId,
                PostTag = postTag,
                PostSortFilterType = postSortFilterType
            };

            return View(blogViewModel);
        }

        [Breadcrumb("ViewData.Title")]
        public async Task<IActionResult> Post(int id)
        {
            var post = await _unitOfWork.PostRepository.GetById(id);

            if (post == null)
            {
                return NotFound();
            }

            var postViewModel = _mapper.Map<Post, PostViewModel>(post);

            var postComments = await _unitOfWork.PostCommentRepository
                .GetAllByPostId(post.Id);

            postViewModel.PostCommentViewModels =
                _mapper.Map<IEnumerable<PostComment>, IEnumerable<PostCommentViewModel>>(postComments);

            return View(postViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CommentPost(PostCommentFormViewModel postCommentFormViewModel)
        {
            if (ModelState.IsValid)
            {
                var postComment = _mapper.Map<PostCommentFormViewModel, PostComment>(postCommentFormViewModel);

                if (_accessor.HttpContext?.Connection.RemoteIpAddress != null)
                {
                    postComment.Ip = _accessor.HttpContext.Connection.RemoteIpAddress.ToString();
                }

                postComment.PostCommentStatus = PostCommentStatus.Unclear;

                _unitOfWork.PostCommentRepository.Insert(postComment);
                await _unitOfWork.Complete();

                return new JsonResult(new JsonResultModel()
                {
                    StatusCode = JsonResultStatusCode.Success,
                    Message = ConstantMessages.CommentSentAndWillShowAfterAcceptance
                });
            }

            return new JsonResult(new JsonResultModel()
            {
                StatusCode = JsonResultStatusCode.ModelStateIsNotValid,
                Message = ConstantMessages.CommentFailedToSend
            });
        }

        [NonAction]
        public PagedList<Post> GetPosts(PostSearch postSearchDto = null, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _unitOfWork.PostRepository.GetAll();

            if (postSearchDto != null)
            {
                if (postSearchDto.PostCategoryId != null)
                {
                    query = query.Where(x => x.PostCategoryId == postSearchDto.PostCategoryId);
                }

                if (!string.IsNullOrWhiteSpace(postSearchDto.PostTag))
                {
                    query = query.Where(x => x.Tags.Contains(postSearchDto.PostTag));
                }

                if (!string.IsNullOrWhiteSpace(postSearchDto.SearchString))
                {
                    string searchString = postSearchDto.SearchString?.ToLower();
                    query = query.Where(
                            x => (x.Title.Contains(searchString) ||
                                  x.Tags.Contains(searchString) ||
                                  x.PostCategory.Title.Contains(searchString) ||
                                  x.Body.Contains(searchString))
                        );
                }

                switch (postSearchDto.PostSortFilterType)
                {
                    case PostSortFilterType.SortByDateAsc:
                        query = query.OrderBy(x => x.CreateDate);
                        break;
                    case PostSortFilterType.SortByDateDesc:
                        query = query.OrderByDescending(x => x.CreateDate);
                        break;
                    default:
                        query = query.OrderByDescending(x => x.CreateDate);
                        break;
                }
            }
            else
            {
                query = query.OrderByDescending(x => x.CreateDate);
            }

            return new PagedList<Post>(query, pageIndex, pageSize);
        }
    }
}