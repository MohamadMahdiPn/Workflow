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
    public class RolesForUsersController : Controller
    {
        // private WFEDbContext db = new WFEDbContext();
        private UnitWork unit = new UnitWork();
        // GET: RolesForUsers
        public ActionResult Index()
        {
            RolesViewModel viewModel = new RolesViewModel();
            viewModel.DataModels = unit.Role.GetAll().ToList();
            return View(viewModel);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RolesViewModel viewModel = new RolesViewModel();
            viewModel.DataModel = unit.Role.GetById(id);
            if (viewModel.DataModel == null)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }

        public ActionResult Create()
        {
            RolesViewModel viewModel = new RolesViewModel();
            viewModel.DataModels = unit.Role.GetAll().ToList();
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RolesViewModel rolesForUsers)
        {
            if (ModelState.IsValid)
            {
                
                unit.Role.Insert(rolesForUsers.DataModel);
                unit.Role.Save();
                return RedirectToAction("Index");
            }

            return View(rolesForUsers);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RolesViewModel viewModel = new RolesViewModel();
            viewModel.DataModel = unit.Role.GetById(id);
            viewModel.DataModels = unit.Role.GetAll().ToList();
            if (viewModel.DataModel == null)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RolesViewModel rolesForUsers)
        {
            if (ModelState.IsValid)
            {
                unit.Role.Update(rolesForUsers.DataModel);
                unit.Role.Save();
                return RedirectToAction("Index");
            }
            return View(rolesForUsers);
        }

       
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RolesViewModel viewModel = new RolesViewModel();
            viewModel.DataModel = unit.Role.GetById(id);
            if (viewModel.DataModel == null)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }

        // POST: RolesForUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RolesViewModel viewModel = new RolesViewModel();
            viewModel.DataModel = unit.Role.GetById(id);
            unit.Role.Delete(viewModel.DataModel);
            unit.Role.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unit.Role.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
