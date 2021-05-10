using System;
using System.Collections.Generic;

namespace AMZEnterpriseWebsite.Core.Domain
{
    public class PostComment : IEntity
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public PostComment Parent { get; set; }
        public ICollection<PostComment> Children { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
        public string UserFullName { get; set; }
        public string Email { get; set; }
        public string Body { get; set; }
        public string Ip { get; set; }
        public PostCommentStatus PostCommentStatus { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastEditDate { get; set; }
        public bool IsEdited { get; set; }
    }
}
