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
    public class BooksController : Controller
    {
        private BookRepository _bookRepo = new BookRepository();
        private AuthorRepository _authorRepo = new AuthorRepository();
        private OwnerRepository _ownerRepo = new OwnerRepository();

        // GET: Books
        public ActionResult Index()
        {
            var books = _bookRepo.ReadAll();

            var list = new List<Book>();

            foreach (var book in books)
            {
                //book.Author = _authorRepo.Read(book.AuthorId);
                //book.Owner = _ownerRepo.Read(book.OwnerId);
                var current = MappingWeb.ConvertToWebEntity(book);
                current.Author = MappingWeb.ConvertToWebEntity(_authorRepo.Read(book.AuthorId));
                current.Owner = MappingWeb.ConvertToWebEntity(_ownerRepo.Read(book.OwnerId));

                list.Add(current);
            }

            return View(list);
        }

        // GET: Books/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = MappingWeb.ConvertToWebEntity(_bookRepo.Read(id));
            book.Author = MappingWeb.ConvertToWebEntity(_authorRepo.Read(book.AuthorId));
            book.Owner = MappingWeb.ConvertToWebEntity(_ownerRepo.Read(book.OwnerId));

            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            ViewBag.AuthorId = new SelectList(_authorRepo.ReadAll(), "Id", "Name");
            //ViewBag.OwnerId = new SelectList(_ownerRepo.ReadAll(), "Id", "Name");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ISBN,countPages,datePublished,AuthorId,OwnerId,isDeleted")] Book book)
        {
            if (ModelState.IsValid)
            {
                book.isDeleted = false;
                book.OwnerId = 17;
                book.Author = MappingWeb.ConvertToWebEntity(_authorRepo.Read(book.AuthorId));
                book.Owner = MappingWeb.ConvertToWebEntity(_ownerRepo.Read(book.OwnerId));
                _bookRepo.Create(MappingWeb.ConvertToBusinessEntity(book));
                return RedirectToAction("Index");
            }


            ViewBag.AuthorId = new SelectList(_authorRepo.ReadAll(), "Id", "Name", book.AuthorId);
            ViewBag.OwnerId = new SelectList(_ownerRepo.ReadAll(), "Id", "Name", book.OwnerId);

            return View(book);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = MappingWeb.ConvertToWebEntity(_bookRepo.Read(id));
            book.Owner = MappingWeb.ConvertToWebEntity(_ownerRepo.Read(book.OwnerId));

            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorId = new SelectList(_authorRepo.ReadAll(), "Id", "Name", book.AuthorId);
            //ViewBag.OwnerId = new SelectList(_ownerRepo.ReadAll(), "Id", "Name", book.OwnerId);
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ISBN,countPages,datePublished,AuthorId")] Book book)
        {
            if (ModelState.IsValid)
            {
                book.Author = MappingWeb.ConvertToWebEntity(_authorRepo.Read(book.AuthorId));
                var ownerIdFromRepo = MappingWeb.ConvertToWebEntity(_bookRepo.Read(book.Id)).OwnerId;
                book.isDeleted = false;
                book.OwnerId = ownerIdFromRepo;
                book.Owner = MappingWeb.ConvertToWebEntity(_ownerRepo.Read(ownerIdFromRepo));
                _bookRepo.Update(MappingWeb.ConvertToBusinessEntity(book));
                return RedirectToAction("Index");
            }
            ViewBag.AuthorId = new SelectList(_authorRepo.ReadAll(), "Id", "Name", book.AuthorId);
            ViewBag.OwnerId = new SelectList(_ownerRepo.ReadAll(), "Id", "Name", book.OwnerId);
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = MappingWeb.ConvertToWebEntity(_bookRepo.Read(id));
            book.Author = MappingWeb.ConvertToWebEntity(_authorRepo.Read(book.AuthorId));
            book.Owner = MappingWeb.ConvertToWebEntity(_ownerRepo.Read(book.OwnerId));

            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = MappingWeb.ConvertToWebEntity(_bookRepo.Read(id));
            _bookRepo.Delete(MappingWeb.ConvertToBusinessEntity(book));
            return RedirectToAction("Index");
        }

        public ActionResult Hire(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = MappingWeb.ConvertToWebEntity(_bookRepo.Read(id));
            if (book == null)
            {
                return HttpNotFound();
            }
            //ViewBag.AuthorId = new SelectList(_authorRepo.ReadAll(), "Id", "Name", book.AuthorId);
            ViewBag.OwnerId = new SelectList(_ownerRepo.ReadAll(), "Id", "Name", book.OwnerId);
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Hire([Bind(Include = "Id,Name,ISBN,countPages,datePublished,AuthorId,OwnerId,isDeleted")] Book book)
        {
            if (ModelState.IsValid)
            {
                book.Name = MappingWeb.ConvertToWebEntity(_bookRepo.Read(book.Id)).Name;
                book.ISBN = MappingWeb.ConvertToWebEntity(_bookRepo.Read(book.Id)).ISBN;
                book.countPages = MappingWeb.ConvertToWebEntity(_bookRepo.Read(book.Id)).countPages;
                book.datePublished = MappingWeb.ConvertToWebEntity(_bookRepo.Read(book.Id)).datePublished;
                book.Owner = MappingWeb.ConvertToWebEntity(_ownerRepo.Read(book.OwnerId));
                var authorIdFromRepo = MappingWeb.ConvertToWebEntity(_bookRepo.Read(book.Id)).AuthorId;
                book.isDeleted = false;
                book.AuthorId = authorIdFromRepo;
                book.Author = MappingWeb.ConvertToWebEntity(_authorRepo.Read(authorIdFromRepo));
                _bookRepo.Update(MappingWeb.ConvertToBusinessEntity(book));
                return RedirectToAction("Index");
            }
            //ViewBag.AuthorId = new SelectList(_authorRepo.ReadAll(), "Id", "Name", book.AuthorId);
            ViewBag.OwnerId = new SelectList(_ownerRepo.ReadAll(), "Id", "Name", book.OwnerId);
            return View(book);
        }
    }
}
