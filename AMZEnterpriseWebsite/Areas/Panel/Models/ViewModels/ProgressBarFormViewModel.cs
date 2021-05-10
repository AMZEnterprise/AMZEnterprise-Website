using System.ComponentModel.DataAnnotations;
using AMZEnterpriseWebsite.Core.Domain;
using AMZEnterpriseWebsite.Models.Constants;

namespace AMZEnterpriseWebsite.Areas.Panel.Models.ViewModels
{
    public class ProgressBarFormViewModel : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "نام")]
        [Required(ErrorMessage = ConstantValidationErrorMessages.RequiredMsg)]
        [MaxLength(256, ErrorMessage = ConstantValidationErrorMessages.MaxLengthMsg)]
        public string Topic { get; set; }
        [Display(Name = "درصد")]
        [Required(ErrorMessage = ConstantValidationErrorMessages.RequiredMsg)]
        [Range(0, 100, ErrorMessage = ConstantValidationErrorMessages.RangeMsg)]
        public int Percentage { get; set; }
        [Display(Name = "ترتیب")]
        [Range(0, int.MaxValue, ErrorMessage = ConstantValidationErrorMessages.RangeMsg)]
        public int SortIndex { get; set; }
    }
}
