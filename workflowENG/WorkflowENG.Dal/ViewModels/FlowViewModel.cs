using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowENG.Dal.DataModel;

namespace WorkflowENG.Dal.ViewModels
{
    public class FlowViewModel:BaseViewModel<Flows>
    {
        public IEnumerable<SampleForm> SampleForms { get; set; }
        public List<string> SchemeCodeList { get; set; }
        public IEnumerable<object> CommandList { get; set; }
        public string SchemeCode { get; set; }
    }
}
