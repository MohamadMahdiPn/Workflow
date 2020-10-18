using OptimaJet.Workflow.Core.Model;
using OptimaJet.Workflow.Core.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Workflow.Web.Models
{
    public class ActionProvider : IWorkflowActionProvider
    {
        private readonly Dictionary<string, Action<ProcessInstance, WorkflowRuntime, string>> _actions = new Dictionary<string, Action<ProcessInstance, WorkflowRuntime, string>>();

        private readonly Dictionary<string, Func<ProcessInstance, WorkflowRuntime, string, CancellationToken, Task>> _asyncActions = new Dictionary<string, Func<ProcessInstance, WorkflowRuntime, string, CancellationToken, Task>>();

        private readonly Dictionary<string, Func<ProcessInstance, WorkflowRuntime, string, bool>> _conditions = new Dictionary<string, Func<ProcessInstance, WorkflowRuntime, string, bool>>();

        private readonly Dictionary<string, Func<ProcessInstance, WorkflowRuntime, string, CancellationToken, Task<bool>>> _asyncConditions = new Dictionary<string, Func<ProcessInstance, WorkflowRuntime, string, CancellationToken, Task<bool>>>();

        public ActionProvider()
        {
            //Register your actions in _actions and _asyncActions dictionaries
            _actions.Add("MyAction", MyAction); //sync
            _asyncActions.Add("MyAsyncAction", MyAsyncAction); //async

            _actions.Add("Mamad", Mamad); //sync
            _asyncActions.Add("AsyncMamad", AsyncMamad); //async

            _actions.Add("Update", Update); //sync
            _asyncActions.Add("AsyncUpdate", AsyncUpdate); //async


            //Register your conditions in _conditions and _asyncConditions dictionaries
            _conditions.Add("MyCondition", MyCondition); //sync
            _asyncConditions.Add("MyAsyncCondition", MyAsyncCondition); //async
        }

        private async Task AsyncUpdate(ProcessInstance processInstance, WorkflowRuntime runtime, string actionParameter, CancellationToken token)
        {
            
            //Execute your asynchronous code here. You can use await in your code.
        }

        private void Update(ProcessInstance processInstance, WorkflowRuntime runtime, string actionParameter)
        {

        }

        private async Task AsyncMamad(ProcessInstance processInstance, WorkflowRuntime runtime, string actionParameter, CancellationToken token)
        {
            //Execute your asynchronous code here. You can use await in your code.
        }

        private void Mamad(ProcessInstance processInstance, WorkflowRuntime runtime, string actionParameter)
        {
            
        }

        private void MyAction(ProcessInstance processInstance, WorkflowRuntime runtime,
            string actionParameter)
        {
            //Execute your synchronous code here
        }

        private async Task MyAsyncAction(ProcessInstance processInstance, WorkflowRuntime runtime, string actionParameter, CancellationToken token)
        {
            //Execute your asynchronous code here. You can use await in your code.
        }

        private bool MyCondition(ProcessInstance processInstance, WorkflowRuntime runtime, string actionParameter)
        {
            //Execute your code here
            return false;
        }

        private async Task<bool> MyAsyncCondition(ProcessInstance processInstance, WorkflowRuntime runtime, string actionParameter, CancellationToken token)
        {
            //Execute your asynchronous code here. You can use await in your code.
            return false;
        }

        #region Implementation of IWorkflowActionProvider

        public void ExecuteAction(string name, ProcessInstance processInstance, WorkflowRuntime runtime,
            string actionParameter)
        {
            if (_actions.ContainsKey(name))
                _actions[name].Invoke(processInstance, runtime, actionParameter);
            
        }

        public async Task ExecuteActionAsync(string name, ProcessInstance processInstance, WorkflowRuntime runtime, string actionParameter, CancellationToken token)
        {
            //token.ThrowIfCancellationRequested(); // You can use the transferred token at your discretion
            if (_asyncActions.ContainsKey(name))
                await _asyncActions[name].Invoke(processInstance, runtime, actionParameter, token);
            
        }

        public bool ExecuteCondition(string name, ProcessInstance processInstance, WorkflowRuntime runtime,
            string actionParameter)
        {
            if (_conditions.ContainsKey(name))
                return _conditions[name].Invoke(processInstance, runtime, actionParameter);
            else
                return false;

        }

        public async Task<bool> ExecuteConditionAsync(string name, ProcessInstance processInstance, WorkflowRuntime runtime, string actionParameter, CancellationToken token)
        {
            //token.ThrowIfCancellationRequested(); // You can use the transferred token at your discretion
            if (_asyncConditions.ContainsKey(name))
                return await _asyncConditions[name].Invoke(processInstance, runtime, actionParameter, token);
            else
                return false;

           
        }

        public bool IsActionAsync(string name)
        {
            return _asyncActions.ContainsKey(name);
        }

        public bool IsConditionAsync(string name)
        {
            return _asyncConditions.ContainsKey(name);

            //public List<string> GetActions()
            //{
            //    return _actions.Keys.Union(_asyncActions.Keys).ToList();
            //}

            // List<string> GetConditions()
            //{
            //    return _conditions.Keys.Union(_asyncConditions.Keys).ToList();
            //}

            #endregion
        }

        public bool IsActionAsync(string name, string schemeCode)
        {
            return _asyncActions.ContainsKey(name);
        }

        public bool IsConditionAsync(string name, string schemeCode)
        {
            throw new NotImplementedException();
        }

        public List<string> GetActions(string schemeCode)
        {
            return _actions.Keys.Union(_asyncActions.Keys).ToList();
        }

        public List<string> GetConditions(string schemeCode)
        {
            return _conditions.Keys.Union(_asyncConditions.Keys).ToList();
        }
    }
}