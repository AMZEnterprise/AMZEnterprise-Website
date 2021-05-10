using System;

namespace AMZEnterpriseWebsite.Core.Domain
{
    public class Contact : IEntity
    {
        public int Id { get; set; }
        public string UserFullName { get; set; }
        public string EmailOrPhoneNumber { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Ip { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastEditDate { get; set; }
    }
}
