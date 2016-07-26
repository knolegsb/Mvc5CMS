using System.Collections.Generic;

namespace Mvc5CMS.Data
{
    public interface ITagRepository
    {
        IEnumerable<string> GetAll();
        bool Exists(string tag);
        void Edit(string existngTag, string newTag);
        void Delete(string tag);
    }
}
