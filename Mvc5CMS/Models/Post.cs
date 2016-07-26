using System;

namespace Mvc5CMS.Models
{
    public class Post
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Published { get; set; }
        public int AuthorId { get; set; }
    }
}