using AMZEnterpriseWebsite.Core.Domain;
using AMZEnterpriseWebsite.Models.ViewModels;
using AMZEnterpriseWebsite.Persistence;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AMZEnterpriseWebsite.ViewComponents
{
    public class CertificatesViewComponent : ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CertificatesViewComponent(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var certificates =
                await _unitOfWork.CertificateRepository.GetAll().ToListAsync();

            return View(_mapper.Map<IEnumerable<Certificate>, IEnumerable<CertificateViewModel>>(certificates));
        }
    }
}
