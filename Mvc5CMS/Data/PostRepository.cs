using Mvc5CMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mvc5CMS.Data
{
    public class PostRepository : IPostRepository
    {
        public void Create(Post model)
        {
            using (var db = new CmsContext())
            {
                var post = db.Posts.SingleOrDefault(p => p.Id == model.Id);

                if (post != null)
                {
                    throw new ArgumentException("A post with the id of " + model.Id + " already exists.");
                }

                //if (string.IsNullOrWhiteSpace(model.Id))
                //{
                //    model.Id = model.Title;
                //}

                //model.Id = model.Id.MakeUrlFriendly();
                //model.Tags = model.Tags.Select(tag => tag.MakeUrlFriendly()).ToList();
                
                db.Posts.Attach(model);
                db.SaveChanges();
            }
        }

        public void Edit(string id, Post updatedItem)
        {
            using (var db = new CmsContext())
            {
                var post = db.Posts.SingleOrDefault(p => p.Id == id);

                if (post == null)
                {
                    throw new KeyNotFoundException("A post with the id of " + id + " does not exist in the data store.");
                }

                //var newId = updatedItem.Id;

                //if (string.IsNullOrWhiteSpace(newId))
                //{
                //    newId = updatedItem.Title;
                //}

                //post.Id = newId.MakeUrlFriendly();

                post.Id = updatedItem.Id;
                post.Title = updatedItem.Title;
                post.Content = updatedItem.Content;
                post.Published = updatedItem.Published;
                post.Tags = updatedItem.Tags;

                db.SaveChanges();
            }
        }

        public Post Get(string id)
        {
            using (var db = new CmsContext())
            {
                return db.Posts.Include("Author").SingleOrDefault(post => post.Id == id);
            }
        }

        public IEnumerable<Post> GetAll()
        {
            using (var db = new CmsContext())
            {
                return db.Posts.Include("Author").OrderByDescending(post => post.Created).ToArray();
            }
        }
    }
}