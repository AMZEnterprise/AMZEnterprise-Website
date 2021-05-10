using System;
using System.Collections.Generic;

namespace AMZEnterpriseWebsite.Core.Domain
{
    public class Post : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastEditDate { get; set; }
        public string Tags { get; set; }
        public int? PostCategoryId { get; set; }
        public PostCategory PostCategory { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public bool IsCommentsOn { get; set; }
        public Guid FilesPathGuid { get; set; }
        public ICollection<PostComment> PostComments { get; set; }
    }
}
