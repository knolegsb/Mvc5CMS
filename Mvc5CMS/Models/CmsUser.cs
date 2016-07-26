using Microsoft.AspNet.Identity.EntityFramework;

namespace Mvc5CMS.Models
{
    public class CmsUser : IdentityUser
    {
        public string DisplayName { get; set; }
    }
}