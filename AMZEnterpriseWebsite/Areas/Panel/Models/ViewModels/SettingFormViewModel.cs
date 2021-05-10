using AMZEnterpriseWebsite.Core.Domain;
using AMZEnterpriseWebsite.Models.Constants;
using System.ComponentModel.DataAnnotations;

namespace AMZEnterpriseWebsite.Areas.Panel.Models.ViewModels
{
    public class SettingFormViewModel : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "تلفن ۱")]
        [MaxLength(20, ErrorMessage = ConstantValidationErrorMessages.MaxLengthMsg)]
        public string Phone1 { get; set; }
        [Display(Name = "تلفن ۲")]
        [MaxLength(20, ErrorMessage = ConstantValidationErrorMessages.MaxLengthMsg)]
        public string Phone2 { get; set; }
        [Display(Name = "ایمیل ۱")]
        [MaxLength(256, ErrorMessage = ConstantValidationErrorMessages.MaxLengthMsg)]
        public string Email1 { get; set; }
        [Display(Name = "ایمیل ۲")]
        [MaxLength(256, ErrorMessage = ConstantValidationErrorMessages.MaxLengthMsg)]
        public string Email2 { get; set; }
        [Display(Name = "آدرس ۱")]
        [MaxLength(1000, ErrorMessage = ConstantValidationErrorMessages.MaxLengthMsg)]
        public string Address1 { get; set; }
        [Display(Name = "آدرس ۲")]
        [MaxLength(1000, ErrorMessage = ConstantValidationErrorMessages.MaxLengthMsg)]
        public string Address2 { get; set; }
        [Display(Name = "اینستاگرام")]
        [MaxLength(256, ErrorMessage = ConstantValidationErrorMessages.MaxLengthMsg)]
        public string Instagram { get; set; }
        [Display(Name = "تلگرام")]
        [MaxLength(256, ErrorMessage = ConstantValidationErrorMessages.MaxLengthMsg)]
        public string Telegram { get; set; }
        [Display(Name = "گوگل پلاس")]
        [MaxLength(256, ErrorMessage = ConstantValidationErrorMessages.MaxLengthMsg)]
        public string GooglePlus { get; set; }
        [Display(Name = "فیسبوک")]
        [MaxLength(256, ErrorMessage = ConstantValidationErrorMessages.MaxLengthMsg)]
        public string FaceBook { get; set; }
        [Display(Name = "لینکدین")]
        [MaxLength(256, ErrorMessage = ConstantValidationErrorMessages.MaxLengthMsg)]
        public string LinkedIn { get; set; }
        [Display(Name = "یوتیوب")]
        [MaxLength(256, ErrorMessage = ConstantValidationErrorMessages.MaxLengthMsg)]
        public string Youtube { get; set; }
        [Display(Name = "آپارات")]
        [MaxLength(256, ErrorMessage = ConstantValidationErrorMessages.MaxLengthMsg)]
        public string Aparat { get; set; }
        [Display(Name = "گیت هاب")]
        [MaxLength(256, ErrorMessage = ConstantValidationErrorMessages.MaxLengthMsg)]
        public string GitHub { get; set; }
        [Display(Name = "نام کیف پول 1")]
        [MaxLength(256, ErrorMessage = ConstantValidationErrorMessages.MaxLengthMsg)]
        public string WalletName1 { get; set; }
        [Display(Name = "آدرس کیف پول 1")]
        [MaxLength(1000, ErrorMessage = ConstantValidationErrorMessages.MaxLengthMsg)]
        public string WalletAddress1 { get; set; }
        [Display(Name = "نام کیف پول 2")]
        [MaxLength(256, ErrorMessage = ConstantValidationErrorMessages.MaxLengthMsg)]
        public string WalletName2 { get; set; }
        [Display(Name = "آدرس کیف پول 2")]
        [MaxLength(1000, ErrorMessage = ConstantValidationErrorMessages.MaxLengthMsg)]
        public string WalletAddress2 { get; set; }
        [Display(Name = "نام کیف پول 3")]
        [MaxLength(256, ErrorMessage = ConstantValidationErrorMessages.MaxLengthMsg)]
        public string WalletName3 { get; set; }
        [Display(Name = "آدرس کیف پول 3")]
        [MaxLength(1000, ErrorMessage = ConstantValidationErrorMessages.MaxLengthMsg)]
        public string WalletAddress3 { get; set; }
        [Display(Name = "نام کیف پول 4")]
        [MaxLength(256, ErrorMessage = ConstantValidationErrorMessages.MaxLengthMsg)]
        public string WalletName4 { get; set; }
        [Display(Name = "آدرس کیف پول 4")]
        [MaxLength(1000, ErrorMessage = ConstantValidationErrorMessages.MaxLengthMsg)]
        public string WalletAddress4 { get; set; }
        [Display(Name = "نام کیف پول 5")]
        [MaxLength(256, ErrorMessage = ConstantValidationErrorMessages.MaxLengthMsg)]
        public string WalletName5 { get; set; }
        [Display(Name = "آدرس کیف پول 5")]
        [MaxLength(1000, ErrorMessage = ConstantValidationErrorMessages.MaxLengthMsg)]
        public string WalletAddress5 { get; set; }
        [Display(Name = "نام کیف پول 6")]
        [MaxLength(256, ErrorMessage = ConstantValidationErrorMessages.MaxLengthMsg)]
        public string WalletName6 { get; set; }
        [Display(Name = "آدرس کیف پول 6")]
        [MaxLength(1000, ErrorMessage = ConstantValidationErrorMessages.MaxLengthMsg)]
        public string WalletAddress6 { get; set; }
        [Display(Name = "نام کیف پول 7")]
        [MaxLength(256, ErrorMessage = ConstantValidationErrorMessages.MaxLengthMsg)]
        public string WalletName7 { get; set; }
        [Display(Name = "آدرس کیف پول 7")]
        [MaxLength(1000, ErrorMessage = ConstantValidationErrorMessages.MaxLengthMsg)]
        public string WalletAddress7 { get; set; }
        [Display(Name = "نام کیف پول 8")]
        [MaxLength(256, ErrorMessage = ConstantValidationErrorMessages.MaxLengthMsg)]
        public string WalletName8 { get; set; }
        [Display(Name = "آدرس کیف پول 8")]
        [MaxLength(1000, ErrorMessage = ConstantValidationErrorMessages.MaxLengthMsg)]
        public string WalletAddress8 { get; set; }
        [Display(Name = "نام کیف پول 9")]
        [MaxLength(256, ErrorMessage = ConstantValidationErrorMessages.MaxLengthMsg)]
        public string WalletName9 { get; set; }
        [Display(Name = "آدرس کیف پول 9")]
        [MaxLength(1000, ErrorMessage = ConstantValidationErrorMessages.MaxLengthMsg)]
        public string WalletAddress9 { get; set; }
        [Display(Name = "نام کیف پول 10")]
        [MaxLength(256, ErrorMessage = ConstantValidationErrorMessages.MaxLengthMsg)]
        public string WalletName10 { get; set; }
        [Display(Name = "آدرس کیف پول 10")]
        [MaxLength(1000, ErrorMessage = ConstantValidationErrorMessages.MaxLengthMsg)]
        public string WalletAddress10 { get; set; }
    }
}
