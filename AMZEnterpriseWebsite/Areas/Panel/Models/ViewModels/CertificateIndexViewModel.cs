using AMZEnterpriseWebsite.Core.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace AMZEnterpriseWebsite.Areas.Panel.Models.ViewModels
{
    public class CertificateIndexViewModel : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "عنوان")]
        public string Title { get; set; }
        [Display(Name = "تاریخ ایجاد")]
        public DateTime CreateDate { get; set; }
        [Display(Name = "تاریخ آخرین ویرایش")]
        public DateTime LastEditDate { get; set; }
    }
}
