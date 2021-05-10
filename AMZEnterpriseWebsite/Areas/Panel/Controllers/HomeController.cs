using AMZEnterpriseWebsite.Models.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AMZEnterpriseWebsite.Areas.Panel.Controllers
{
    [Area(ConstantAreas.Panel)]
    [Authorize]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
