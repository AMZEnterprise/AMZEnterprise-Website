using System;
using AMZEnterpriseWebsite.Areas.Panel.Extensions;
using AMZEnterpriseWebsite.Areas.Panel.Models;
using AMZEnterpriseWebsite.Areas.Panel.Models.ViewModels;
using AMZEnterpriseWebsite.Core.Domain;
using AMZEnterpriseWebsite.Models.Constants;
using AMZEnterpriseWebsite.Persistence;
using AMZEnterpriseWebsite.Services.FileHandler;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMZEnterpriseWebsite.Areas.Panel.Controllers
{
    [Area(ConstantAreas.Panel)]
    [Authorize(Roles = ConstantUserRoles.SuperAdmin + "," + ConstantUserRoles.Admin)]
    public class CertificatesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IFileHandler _fileHandler;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CertificatesController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IFileHandler fileHandler,
            IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _fileHandler = fileHandler;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoadCertificatesTable([FromBody] DTParameters dtParameters)
        {
            var searchBy = dtParameters.Search?.Value;

            var orderCriteria = string.Empty;
            var orderAscendingDirection = true;

            if (dtParameters.Order != null)
            {
                // in this example we just default sort on the 1st column
                orderCriteria = dtParameters.Columns[dtParameters.Order[0].Column].Data;
                orderAscendingDirection = dtParameters.Order[0].Dir.ToString().ToLower() == "asc";
            }
            else
            {
                // if we have an empty search then just order the results by Id ascending
                orderCriteria = "Id";
                orderAscendingDirection = true;
            }

            var result = _unitOfWork.CertificateRepository.GetAll();

            if (!string.IsNullOrWhiteSpace(searchBy))
            {
                result = result.Where(r =>
                    (r.Title != null && r.Title.Contains(searchBy)) ||
                    (r.CreateDate.ToString("F") != null && r.CreateDate.ToString("F").Contains(searchBy)) ||
                    (r.LastEditDate.ToString("F") != null && r.LastEditDate.ToString("F").Contains(searchBy))
                );
            }

            result = orderAscendingDirection ?
                result.OrderByDynamic(orderCriteria, LinqExtensions.Order.Asc) :
                result.AsQueryable().OrderByDynamic(orderCriteria, LinqExtensions.Order.Desc);

            // now just get the count of items (without the skip and take) - eg how many could be returned with filtering
            var filteredResultsCount = result.Count();
            var totalResultsCount = await _unitOfWork.ContactRepository.Count();

            var resultList = result
                .Skip(dtParameters.Start)
                .Take(dtParameters.Length)
                .ToList();

            return new JsonResult(new DatatableJsonResultModel()
            {
                Draw = dtParameters.Draw,
                RecordsTotal = totalResultsCount,
                RecordsFiltered = filteredResultsCount,
                Data = _mapper
                    .Map<IEnumerable<Certificate>, IEnumerable<CertificateIndexViewModel>>(resultList)
            });
        }

        public async Task<IActionResult> Details(int id)
        {
            var certificate = await _unitOfWork.CertificateRepository.GetById(id);

            if (certificate == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<Certificate, CertificateFormViewModel>(certificate));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CertificateFormViewModel certificateFormViewModel)
        {
            if (ModelState.IsValid)
            {
                var certificate = _mapper.Map<CertificateFormViewModel, Certificate>(certificateFormViewModel);

                certificate.FilesPathGuid = Guid.NewGuid();

                _unitOfWork.CertificateRepository.Insert(certificate);
                await _unitOfWork.Complete();

                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0)
                {
                    await _fileHandler.UploadMedia(
                        files,
                        _webHostEnvironment.WebRootPath,
                        certificate.FilesPathGuid.ToString(),
                        FileHandlerFolder.Certificates);
                }

                return RedirectToAction(nameof(Index));
            }

            return View(certificateFormViewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var certificate = await _unitOfWork.CertificateRepository.GetById(id);

            if (certificate == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<Certificate, CertificateFormViewModel>(certificate));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CertificateFormViewModel certificateFormViewModel)
        {
            if (id != certificateFormViewModel.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var certificate = _mapper.Map<CertificateFormViewModel, Certificate>(certificateFormViewModel);

                _unitOfWork.CertificateRepository.Update(certificate);
                await _unitOfWork.Complete();

                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0)
                {
                    //Delete old file
                    _fileHandler.DeleteMedia(
                        _webHostEnvironment.WebRootPath,
                        certificate.FilesPathGuid.ToString(),
                        FileHandlerFolder.Certificates
                    );

                    //Upload new file
                    await _fileHandler.UploadMedia(
                        files,
                        _webHostEnvironment.WebRootPath,
                        certificate.FilesPathGuid.ToString(),
                        FileHandlerFolder.Certificates);
                }

                return RedirectToAction(nameof(Index));
            }

            return View(certificateFormViewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var certificate = await _unitOfWork.CertificateRepository.GetById(id);

            if (certificate == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<Certificate, CertificateFormViewModel>(certificate));
        }

        [HttpPost, ActionName(nameof(Delete))]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _unitOfWork.CertificateRepository.Delete(id);
            await _unitOfWork.Complete();

            return RedirectToAction(nameof(Index));
        }
    }
}
