using Mvc5CMS.Data;
using Mvc5CMS.Models;
using System.Web.Mvc;

namespace Mvc5CMS.Areas.Admin.Controllers
{
    [RouteArea("Admin")]
    [RoutePrefix("post")]
    public class PostController : Controller
    {
        private readonly IPostRepository _repository;

        public PostController(IPostRepository repository)
        {
            _repository = repository;
        }

        // GET: Admin/Post
        public ActionResult Index()
        {
            return View();
        }

        // Admin/Post/Create
        [HttpGet]
        [Route("create")]
        public ActionResult Create()
        {
            var model = new Post();
            return View(model);
        }

        // Admin/Post/Create
        [HttpPost]
        [Route("create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Post model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // TODO: update model in data store

            return RedirectToAction("Index");
        }

        // Admin/Post/Edit/Post-To-Edit
        [HttpGet]
        [Route("edit/{postId}")]
        public ActionResult Edit(string postId)
        {
            // TODO: to retrieve the model from the data store
            var post = _repository.Get(postId);
            //var model = new Post();

            if (post == null)
            {
                return HttpNotFound();
            }

            return View(post);
        }

        // Admin/Post/Edit/Post-To-Edit
        [HttpPost]
        [Route("edit/{postId}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string postId, Post model)
        {
            var post = _repository.Get(postId);

            if (post == null)
            {
                return HttpNotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            _repository.Edit(postId, model);

            return RedirectToAction("Index");
        }
    }
}