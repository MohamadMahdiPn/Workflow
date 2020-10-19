using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorkflowENG.Dal.Repository;
using WorkflowENG.Dal.ViewModels;

namespace Workflow.Web.Controllers
{
    public class HomeController : Controller
    {
        private IUnitWork _unit;
        public HomeController(IUnitWork Unit)
        {
            _unit = Unit;
        }
        public ActionResult Index()
        {

            UsersViewModel viewModel = new UsersViewModel();
            viewModel.DataModels = _unit.Users.GetAll().ToList();
            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}