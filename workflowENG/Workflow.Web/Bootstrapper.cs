using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc3;
using Workflow.Web.Models;
using WorkflowENG.Dal.Repository;

namespace Workflow.Web
{
    public static class Bootstrapper
    {
        [System.Obsolete]
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        [System.Obsolete]
        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<IUnitWork, UnitWork>();
            container.RegisterType<IWorkflowService, WorkflowService>();


            return container;
        }
    }
}