using OptimaJet.Workflow.Core.Runtime;
using System;
using System.Collections.Generic;

namespace Workflow.Web.Models
{
    public interface IWorkflowService
    {
        List<string> GetSchemes();
        Guid StartFlow(string SchemeCode);
        WorkflowState MoveFlow(Guid? ProcessId, string IdentityId, string action);
        IEnumerable<WorkflowCommand> WorkflowCommands(Guid ProcessId, string IdentityId);
    }
}