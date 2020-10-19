using OptimaJet.Workflow.Core.Runtime;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Web;

namespace Workflow.Web.Models
{  
    [Obsolete]
    public class WorkflowService: IWorkflowService
    {
      
        public List<string> GetSchemes()
        {
            var processInstance = workflowModel.Runtime.GetSchemeCodes();
            return processInstance;
        }

        public Guid StartFlow(string SchemeCode)
        {
            Guid guid = Guid.NewGuid();
            var createInstanceParameters = new CreateInstanceParams(SchemeCode, guid);
              //.AddPersistentParameter("StringParameter", "Some String")
              //.AddPersistentParameter("ObjectParameter", "1");
            workflowModel.Runtime.CreateInstance(createInstanceParameters);
            return guid;
        }
        public WorkflowState MoveFlow(Guid? ProcessId , string IdentityId, string action)
        {
            var commands = workflowModel.Runtime.GetAvailableCommands(ProcessId.Value, IdentityId);
            var command = commands.FirstOrDefault(c => c.CommandName == action);
            workflowModel.Runtime.ExecuteCommand(command, IdentityId, IdentityId);
            var CurrentState = workflowModel.Runtime.GetCurrentState(ProcessId.Value, null);
            return CurrentState;
        }

        public IEnumerable<WorkflowCommand> WorkflowCommands(Guid ProcessId, string IdentityId)
        {
            var commands = workflowModel.Runtime.GetAvailableCommands(ProcessId, IdentityId);
            //var commands2 = workflowModel.Runtime.GetAvailableCommandsWithConditionCheck(ProcessId, IdentityId);

            return commands ;
        }


    }
}