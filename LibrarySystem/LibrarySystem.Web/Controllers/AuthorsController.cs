using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LibrarySystem.Web.Models;
using LibrarySystem.DataAccessLayer;

namespace LibrarySystem.Web.Controllers
{
    public class AuthorsController : Controller
    {
        private AuthorRepository _authorRepo = new AuthorRepository();

        // GET: Authors
        public ActionResult Index()
        {
            var authors = _authorRepo.ReadAll();

            var list = new List<Author>();

            foreach (var author in authors)
            {
                list.Add(MappingWeb.ConvertToWebEntity(author));
            }

            return View(list);
        }

        // GET: Authors/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = MappingWeb.ConvertToWebEntity(_authorRepo.Read(id));
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // GET: Authors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Authors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Gender,Birthdate")] Author author)
        {
            if (ModelState.IsValid)
            {
                author.isDeleted = false;
                _authorRepo.Create(MappingWeb.ConvertToBusinessEntity(author));
                //_authorRepo.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(author);
        }

        // GET: Authors/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = MappingWeb.ConvertToWebEntity(_authorRepo.Read(id));
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // POST: Authors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Gender,Birthdate,isDeleted")] Author author)
        {
            if (ModelState.IsValid)
            {
                _authorRepo.Update(MappingWeb.ConvertToBusinessEntity(author)); // = EntityState.Modified;
                return RedirectToAction("Index");
            }
            return View(author);
        }

        // GET: Authors/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = MappingWeb.ConvertToWebEntity(_authorRepo.Read(id));
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Author author = MappingWeb.ConvertToWebEntity(_authorRepo.Read(id));
            _authorRepo.Delete(MappingWeb.ConvertToBusinessEntity(author));
            return RedirectToAction("Index");
        }

    }
}
