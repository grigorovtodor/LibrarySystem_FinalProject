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
    public class OwnersController : Controller
    {
        private OwnerRepository _ownerRepo = new OwnerRepository();
        private BookRepository _bookRepo = new BookRepository();

        // GET: Owners
        public ActionResult Index()
        {
            var owners = _ownerRepo.ReadAll();

            var list = new List<Owner>();

            foreach (var owner in owners)
            {
                list.Add(MappingWeb.ConvertToWebEntity(owner));
            }

            return View(list);
        }

        // GET: Owners/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Owner owner = MappingWeb.ConvertToWebEntity(_ownerRepo.Read(id));
            if (owner == null)
            {
                return HttpNotFound();
            }
            return View(owner);
        }

        // GET: Owners/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Owners/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,UniqueIdNumber,Address,Gender,PhoneNumber,Email,isDeleted")] Owner owner)
        {
            if (ModelState.IsValid)
            {
                owner.isDeleted = false;
                _ownerRepo.Create(MappingWeb.ConvertToBusinessEntity(owner));
                return RedirectToAction("Index");
            }

            return View(owner);
        }

        // GET: Owners/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Owner owner = MappingWeb.ConvertToWebEntity(_ownerRepo.Read(id));
            if (owner == null)
            {
                return HttpNotFound();
            }
            return View(owner);
        }

        // POST: Owners/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,UniqueIdNumber,Address,Gender,PhoneNumber,Email,isDeleted")] Owner owner)
        {
            if (ModelState.IsValid)
            {
                _ownerRepo.Update(MappingWeb.ConvertToBusinessEntity(owner)); // = EntityState.Modified;
                return RedirectToAction("Index");
            }
            return View(owner);
        }

        // GET: Owners/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Owner owner = MappingWeb.ConvertToWebEntity(_ownerRepo.Read(id));
            if (owner == null)
            {
                return HttpNotFound();
            }
            return View(owner);
        }

        // POST: Owners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Owner owner = MappingWeb.ConvertToWebEntity(_ownerRepo.Read(id));
            _ownerRepo.Delete(MappingWeb.ConvertToBusinessEntity(owner));
            return RedirectToAction("Index");
        }
    }
}
