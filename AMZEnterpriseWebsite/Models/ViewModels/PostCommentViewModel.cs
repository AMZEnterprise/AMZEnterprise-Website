using System;
using AMZEnterpriseWebsite.Core.Domain;

namespace AMZEnterpriseWebsite.Models.ViewModels
{
    public class PostCommentViewModel : IEntity
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Body { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsEdited { get; set; }
        public string UserFullName { get; set; }
    }
}
