using AMZEnterpriseWebsite.Areas.Panel.Models.ViewModels;
using AMZEnterpriseWebsite.Core.Domain;
using AMZEnterpriseWebsite.Models;
using AMZEnterpriseWebsite.Models.Constants;
using AMZEnterpriseWebsite.Persistence;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMZEnterpriseWebsite.Areas.Panel.Controllers
{
    [Area(ConstantAreas.Panel)]
    [Authorize(Roles = ConstantUserRoles.SuperAdmin + "," + ConstantUserRoles.Admin)]
    public class ProgressBarsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProgressBarsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var progressBars =
                await _unitOfWork.ProgressBarRepository.GetAll()
                    .OrderBy(x => x.SortIndex)
                    .ToListAsync();

            if (progressBars == null)
            {
                return NotFound();
            }

            var progressBarIndexViewModel = new ProgressBarIndexViewModel()
            {
                ProgressBarFormViewModels =
                    _mapper.Map<IEnumerable<ProgressBar>, IList<ProgressBarFormViewModel>>(progressBars)

            };

            return View(progressBarIndexViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(int id, ProgressBarIndexViewModel progressBarIndexViewModel)
        {
            if (id != progressBarIndexViewModel.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var progressBars =
                    _mapper.Map<IList<ProgressBarFormViewModel>, IEnumerable<ProgressBar>>(progressBarIndexViewModel.ProgressBarFormViewModels);

                _unitOfWork.ProgressBarRepository.UpdateAll(progressBars);
                await _unitOfWork.Complete();

                return RedirectToAction(nameof(Index));
            }

            return View(progressBarIndexViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProgressBarFormViewModel progressBarFormViewModel)
        {
            if (ModelState.IsValid)
            {
                var progressBar =
                    _mapper.Map<ProgressBarFormViewModel, ProgressBar>(progressBarFormViewModel);

                await _unitOfWork.ProgressBarRepository.Insert(progressBar);
                await _unitOfWork.Complete();

                return RedirectToAction(nameof(Index));
            }

            return View(progressBarFormViewModel);
        }

        [HttpPost]
        public async Task<JsonResult> Delete(int id)
        {
            await _unitOfWork.ProgressBarRepository.Delete(id);
            await _unitOfWork.Complete();

            return new JsonResult(new JsonResultModel()
            {
                StatusCode = JsonResultStatusCode.Success,
                RedirectUrl = Url.Action(nameof(Index), "ProgressBars")
            });
        }
    }
}
