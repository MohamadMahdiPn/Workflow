using OptimaJet.Workflow.Core.Builder;
using OptimaJet.Workflow.Core.Runtime;
using OptimaJet.Workflow.DbPersistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Workflow.Web.Models
{
    public class workflowModel
    {
        [Obsolete]
        private static readonly Lazy<WorkflowRuntime> lazyRuntime = new Lazy<WorkflowRuntime>(InitWorkflowRuntime);

        [Obsolete]
        public static WorkflowRuntime Runtime => lazyRuntime.Value;

        public static string Connectionstring { get; set; }

        [Obsolete]
        private static WorkflowRuntime InitWorkflowRuntime()
        {
            Connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            if (string.IsNullOrEmpty(Connectionstring))
            {
                throw new Exception("ارتباط با پایگاه داده بررسی شود");
            }
            var dbProvider = new MSSQLProvider(Connectionstring);
            var builder = new WorkflowBuilder<XElement>(
                dbProvider,
                new OptimaJet.Workflow.Core.Parser.XmlWorkflowParser(),
                dbProvider).WithDefaultCache();

            var runtime = new WorkflowRuntime()
                           .WithBuilder(builder)
                           .WithPersistenceProvider(dbProvider)
                           .EnableCodeActions()
                           .SwitchAutoUpdateSchemeBeforeGetAvailableCommandsOn()
                           .AsSingleServer();
            runtime.ProcessActivityChanged += (sender, args) => { };
            runtime.ProcessStatusChanged += (sender, args) => { };
            runtime.Start();
            return runtime;
        }


    }
}