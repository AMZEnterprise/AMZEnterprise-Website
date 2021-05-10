using AMZEnterpriseWebsite.Core.Domain;
using AMZEnterpriseWebsite.Models.Constants;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace AMZEnterpriseWebsite.Areas.Panel.Models.ViewModels
{
    public class CertificateFormViewModel : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = ConstantValidationErrorMessages.RequiredMsg)]
        [MaxLength(256, ErrorMessage = ConstantValidationErrorMessages.MaxLengthMsg)]
        public string Title { get; set; }
        [Display(Name = "لینک")]
        [MaxLength(1000, ErrorMessage = ConstantValidationErrorMessages.MaxLengthMsg)]
        public string Url { get; set; }
        public Guid FilesPathGuid { get; set; }
        [Display(Name = "تاریخ ایجاد")]
        public DateTime CreateDate { get; set; }
        [Display(Name = "تاریخ آخرین ویرایش")]
        public DateTime LastEditDate { get; set; }
        [Display(Name = "تصویر مدرک")]
        public IFormFile File { get; set; }
        public string FilePath { get; set; }
    }
}
