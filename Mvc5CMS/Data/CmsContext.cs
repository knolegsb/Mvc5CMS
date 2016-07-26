using Microsoft.AspNet.Identity.EntityFramework;
using Mvc5CMS.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Mvc5CMS.Data
{
    public class CmsContext : IdentityDbContext<CmsUser>
    {
        public CmsContext() : base("CmsContext")
        {
            
        }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Post>()
                .HasKey(e => e.Id)
                .Property(e => e.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            modelBuilder.Entity<Post>()
                .HasRequired(e => e.Author);
        }
    }
}