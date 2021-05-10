using System;

namespace AMZEnterpriseWebsite.Core.Domain
{
    public class Certificate : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public Guid FilesPathGuid { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastEditDate { get; set; }
    }
}
