using System.ComponentModel.DataAnnotations;

namespace AMZEnterpriseWebsite.Areas.Panel.Models.ViewModels
{
    public enum UserRoleEnumViewModel
    {
        [Display(Name = "مدیر کل", Order = 0)]
        SuperAdmin,
        [Display(Name = "مدیر", Order = 1)]
        Admin,
        [Display(Name = "نویسنده", Order = 2)]
        Writer,
    }
}
