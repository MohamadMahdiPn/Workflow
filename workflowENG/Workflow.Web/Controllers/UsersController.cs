using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WorkflowENG.Dal.DataModel;
using WorkflowENG.Dal.Repository;
using WorkflowENG.Dal.ViewModels;

namespace Workflow.Web.Controllers
{
    public class UsersController : Controller
    {
        //private WFEDbContext db = new WFEDbContext();
        private UnitWork unit = new UnitWork();
        // GET: Users
        public ActionResult Index()
        {
            UsersViewModel viewModel = new UsersViewModel();
            viewModel.DataModels = unit.Users.GetAll().ToList();
            return View(viewModel);
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            UsersViewModel viewModel = new UsersViewModel();
            viewModel.DataModel = unit.Users.GetById(id);
            if (viewModel.DataModel == null)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }

        public ActionResult Create()
        {
            UsersViewModel viewModel = new UsersViewModel();
            viewModel.Roles = unit.Role.GetAll().ToList();
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsersViewModel users)
        {
            if (ModelState.IsValid)
            {
                Guid G = Guid.NewGuid();
                users.DataModel.GUID = G;
                unit.Users.Insert(users.DataModel);
                unit.Users.Save();
                return RedirectToAction("Index");
            }

            return View(users.DataModel);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersViewModel viewModel = new UsersViewModel();
            viewModel.DataModel = unit.Users.GetById(id);
            viewModel.Roles = unit.Role.GetAll();
            if (viewModel.DataModel == null)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UsersViewModel users)
        {
            if (ModelState.IsValid)
            {
                unit.Users.Update(users.DataModel);
                unit.Users.Save();
                return RedirectToAction("Index");
            }
            return View(users);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = unit.Users.GetById(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Users users = unit.Users.GetById(id);
            unit.Users.Delete(users);
            unit.Users.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unit.Users.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
