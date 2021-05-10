using AMZEnterpriseWebsite.Core.Domain;
using AMZEnterpriseWebsite.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using System.Linq;
using System.Threading.Tasks;
using AMZEnterpriseWebsite.Models;
using AMZEnterpriseWebsite.Models.Constants;
using AMZEnterpriseWebsite.Models.ViewModels;
using AutoMapper;

namespace AMZEnterpriseWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public HomeController(
            IUnitOfWork unitOfWork, 
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }


        [DefaultBreadcrumb("صفحه اصلی")]
        public IActionResult Index()
        {
            return View();
        }


        [Breadcrumb("تماس با من")]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Breadcrumb("تماس با من")]
        public async Task<IActionResult> Contact(ContactFormViewModel contactFormViewModel)
        {
            if (ModelState.IsValid)
            {
                var contact = _mapper.Map<ContactFormViewModel, Contact>(contactFormViewModel);

                if (_httpContextAccessor.HttpContext?.Connection.RemoteIpAddress != null)
                {
                    contact.Ip = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
                }

                _unitOfWork.ContactRepository.Insert(contact);
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

        [Breadcrumb("درباره")]
        public IActionResult About()
        {
            return View();
        }

        [Breadcrumb("حمایت مالی")]
        public async Task<IActionResult> Donate()
        {
            var settings = await _unitOfWork.SettingRepository.Get();

            return View(_mapper.Map<Setting,DonateViewModel>(settings));
        }
    }
}