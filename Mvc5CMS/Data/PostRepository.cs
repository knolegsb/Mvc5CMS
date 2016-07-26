using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mvc5CMS.Models;

namespace Mvc5CMS.Data
{
    public class PostRepository : IPostRepository
    {
        public void Create(Post model)
        {
            throw new NotImplementedException();
        }

        public void Edit(string id, Post updatedItem)
        {
            throw new NotImplementedException();
        }

        public Post Get(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}