using AMZEnterpriseWebsite.Core.Domain;
using System.Collections.Generic;

namespace AMZEnterpriseWebsite.Areas.Panel.Models.ViewModels
{
    public class ProgressBarIndexViewModel : IEntity
    {
        public int Id { get; set; }
        public IList<ProgressBarFormViewModel> ProgressBarFormViewModels { get; set; }
    }
}
