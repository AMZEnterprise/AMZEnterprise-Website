using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace AMZEnterpriseWebsite.Core.Domain
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Biography { get; set; }
        public bool IsActive { get; set; }
        public Guid FilesPathGuid { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastEditDate { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<PostComment> PostComments { get; set; }
    }
}
