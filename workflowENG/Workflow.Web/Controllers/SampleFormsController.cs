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
    public class SampleFormsController : Controller
    {
        //private WFEDbContext db = new WFEDbContext();
        UnitWork unit = new UnitWork();
        // GET: SampleForms
        public ActionResult Index()
        {
            SampleFormViewModel viewModel = new SampleFormViewModel();
            viewModel.DataModels = unit.Form.GetAll().ToList();
            return View(viewModel);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SampleFormViewModel viewModel = new SampleFormViewModel();
            viewModel.DataModel = unit.Form.GetById(id);
            if (viewModel.DataModel == null)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SampleFormViewModel sampleForm)
        {
            if (ModelState.IsValid)
            {
                unit.Form.Insert(sampleForm.DataModel);
                unit.Form.Save();
                return RedirectToAction("Index");
            }

            return View(sampleForm);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SampleFormViewModel viewModel = new SampleFormViewModel();
            viewModel.DataModel = unit.Form.GetById(id);
            if (viewModel.DataModel == null)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SampleFormViewModel sampleForm)
        {
            if (ModelState.IsValid)
            {
                unit.Form.Update(sampleForm.DataModel);
                unit.Form.Save();
                return RedirectToAction("Index");
            }
            return View(sampleForm);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SampleFormViewModel viewModel = new SampleFormViewModel();
            viewModel.DataModel = unit.Form.GetById(id);
            if (viewModel.DataModel == null)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }

        // POST: SampleForms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SampleFormViewModel viewModel = new SampleFormViewModel();
            viewModel.DataModel = unit.Form.GetById(id);
            unit.Form.Delete(viewModel.DataModel);
            unit.Form.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unit.Form.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
