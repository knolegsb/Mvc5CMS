﻿using System.Collections.Generic;
using Mvc5CMS.Data;
using System.Linq;
using System.Web.Mvc;
using Mvc5CMS.Models;

namespace Mvc5CMS.Areas.Admin.Controllers
{
    public class TagController : Controller
    {
        private readonly ITagRepository _repository;

        public TagController(ITagRepository repository)
        {
            _repository = repository;
        }

        // GET: Admin/Tag
        public ActionResult Index()
        {
            var tags = _repository.GetAll();
            return View();
        }

        [HttpGet]
        public ActionResult Edit(string tag)
        {
            if (!_repository.Exists(tag))
            {
                return HttpNotFound();
            }
            return View(tag);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string tag, string newTag)
        {
            var tags = _repository.GetAll().ToList();

            if (!tags.Contains(tag))
            {
                return HttpNotFound();
            }

            if (tags.Contains(newTag))
            {
                return RedirectToAction("Index");
            }

            if (string.IsNullOrWhiteSpace(newTag))
            {
                ModelState.AddModelError("key", "New tag value cannot be empty.");
                return View(tag);
            }

            _repository.Edit(tag, newTag);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(string tag)
        {
            if (!_repository.Exists(tag))
            {
                return HttpNotFound();
            }
            return View(tag);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string tag)
        {
            if (!_repository.Exists(tag))
            {
                return HttpNotFound();
            }

            _repository.Delete(tag);
            return RedirectToAction("Index");
        }
    }
}