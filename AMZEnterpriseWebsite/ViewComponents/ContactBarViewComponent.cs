using AMZEnterpriseWebsite.Persistence;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AMZEnterpriseWebsite.ViewComponents
{
    public class ContactBarViewComponent : ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;

        public ContactBarViewComponent(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var setting = await _unitOfWork.SettingRepository.Get();

            return View(setting);
        }
    }
}
