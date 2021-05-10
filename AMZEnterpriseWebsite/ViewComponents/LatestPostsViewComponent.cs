using AMZEnterpriseWebsite.Core.Domain;
using AMZEnterpriseWebsite.Models.ViewModels;
using AMZEnterpriseWebsite.Persistence;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMZEnterpriseWebsite.ViewComponents
{
    public class LatestPostsViewComponent : ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LatestPostsViewComponent(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var posts = await _unitOfWork.PostRepository
                .GetAll()
                .OrderByDescending(x => x.CreateDate)
                .Take(2)
                .ToListAsync();

            return View(_mapper.Map<IEnumerable<Post>, IEnumerable<PostViewModel>>(posts));
        }
    }
}
