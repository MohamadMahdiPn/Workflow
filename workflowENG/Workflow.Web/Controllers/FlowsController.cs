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
    public class FlowsController : Controller
    {
        //private WFEDbContext db = new WFEDbContext();
        private UnitWork unit = new UnitWork();
        // GET: Flows
        public ActionResult Index()
        {
            FlowViewModel viewModel = new FlowViewModel();
            viewModel.DataModels = unit.Flows.GetAll().Include(f => f.SampleForm).ToList();
            //var flows = db.Flows.Include(f => f.SampleForm);
            return View(viewModel);
        }

        // GET: Flows/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlowViewModel viewModel = new FlowViewModel();
            viewModel.DataModel = unit.Flows.GetById(id);
            if (viewModel.DataModel == null)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }

        // GET: Flows/Create
        public ActionResult Create()
        {
            FlowViewModel viewModel = new FlowViewModel();
            viewModel.SampleForms = unit.Form.GetAll().ToList();
            //ViewBag.SampleFormId = new SelectList(db.SampleForms, "Id", "Message");
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FlowViewModel flows)
        {
            if (ModelState.IsValid)
            {
                unit.Flows.Insert(flows.DataModel);
                unit.Flows.Save();
                return RedirectToAction("Index");
            }
            flows.SampleForms = unit.Form.GetAll().ToList();
            //ViewBag.SampleFormId = new SelectList(db.SampleForms, "Id", "Message", flows.SampleFormId);
            return View(flows);
        }

        // GET: Flows/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlowViewModel viewModel = new FlowViewModel();
            viewModel.DataModel = unit.Flows.GetById(id);
            viewModel.SampleForms = unit.Form.GetAll().ToList();
            //Flows flows = db.Flows.Find(id);
            if (viewModel.DataModel == null)
            {
                return HttpNotFound();
            }
           
            // ViewBag.SampleFormId = new SelectList(db.SampleForms, "Id", "Message", flows.SampleFormId);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FlowViewModel flows)
        {
            if (ModelState.IsValid)
            {
                unit.Flows.Update(flows.DataModel);
                unit.Flows.Save();
                return RedirectToAction("Index");
            }
            flows.SampleForms = unit.Form.GetAll().ToList(); 
            // ViewBag.SampleFormId = new SelectList(db.SampleForms, "Id", "Message", flows.SampleFormId);
            return View(flows);
        }

        // GET: Flows/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlowViewModel viewModel = new FlowViewModel();
            viewModel.DataModel = unit.Flows.GetById(id);
            if (viewModel.DataModel == null)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }

        // POST: Flows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FlowViewModel viewModel = new FlowViewModel();
            viewModel.DataModel = unit.Flows.GetById(id);
            unit.Flows.Delete(viewModel.DataModel);
            unit.Flows.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
               unit.Flows.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
