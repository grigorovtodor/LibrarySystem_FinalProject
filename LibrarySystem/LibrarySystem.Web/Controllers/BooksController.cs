using LibrarySystem.BusinessObjects;
using LibrarySystem.DataAccessLayer;
using LibrarySystem.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibrarySystem.Web.Controllers
{
    public class BooksController : Controller
    {
        private BookRepository _bookRepo = new BookRepository();

        // GET: Books
        public ActionResult Index()
        {
            var books = _bookRepo.ReadAll();

            var list = new List<Book>();

            foreach (var book in books)
            {
                list.Add(new Book
                {
                    Id = book.Id,
                    ISBN = book.ISBN,
                    countPages = book.countPages,
                    Name = book.Name,
                    datePublished = book.datePublished,
                    Author = new Author { Name = book.Author.Name, Id = book.AuthorId,
                        Birthdate = book.Author.Birthdate, Gender = book.Author.Gender, isDeleted = book.Author.isDeleted },
                    Owner = new Owner {  Name = book.Owner.Name, UniqueIdNumber = book.Owner.UniqueIdNumber, PhoneNumber = book.Owner.PhoneNumber,
                        Email = book.Owner.Email, Address = book.Owner.Address, Gender = book.Owner.Gender}
                });
            }
            return View(list);
        }

        // GET: Books/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Books/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Books/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
