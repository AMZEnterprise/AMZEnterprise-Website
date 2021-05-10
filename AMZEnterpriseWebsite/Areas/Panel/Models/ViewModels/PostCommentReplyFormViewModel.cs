using AMZEnterpriseWebsite.Models.Constants;
using System.ComponentModel.DataAnnotations;

namespace AMZEnterpriseWebsite.Areas.Panel.Models.ViewModels
{
    public class PostCommentReplyFormViewModel
    {
        public int? PostId { get; set; }
        public int ParentId { get; set; }
        [Display(Name = "نظر پدر")]
        public string ParentBody { get; set; }
        [Display(Name = "متن")]
        [Required(ErrorMessage = ConstantValidationErrorMessages.RequiredMsg)]
        [MaxLength(1000, ErrorMessage = ConstantValidationErrorMessages.MaxLengthMsg)]
        public string Body { get; set; }
        [Display(Name = "وضعیت")]
        public PostCommentStatusEnumViewModel Status { get; set; }
    }
}
