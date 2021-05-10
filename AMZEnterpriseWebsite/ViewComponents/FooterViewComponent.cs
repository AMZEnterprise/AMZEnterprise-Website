using System.Collections.Generic;
using AMZEnterpriseWebsite.Core.Domain;
using AMZEnterpriseWebsite.Models.ViewModels;
using AMZEnterpriseWebsite.Persistence;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AMZEnterpriseWebsite.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FooterViewComponent(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var settings = await _unitOfWork.SettingRepository.Get();

            var footerViewModel = _mapper.Map<Setting, FooterViewModel>(settings);

            var post = await _unitOfWork.PostRepository
                .GetAll()
                .OrderByDescending(x => x.CreateDate)
                .FirstOrDefaultAsync();

            if (post != null)
            {
                if (!string.IsNullOrWhiteSpace(post.Tags))
                {
                    var postTags = new List<string>();

                    foreach (var tag in post.Tags.Split(','))
                    {
                        postTags.Add(tag);
                    }

                    footerViewModel.PostTags = postTags;
                }
            }

            return View(footerViewModel);
        }
    }
}
