using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkflowENG.Dal.DataModel
{
    public class Flows: BaseEntity
    {
       
        public int SampleFormId { get; set; }
        public SampleForm SampleForm { get; set; }
        public Guid WorkflowInstanceId { get; set; }
        public string WorkflowSchemeName { get; set; }
        public string CurrentStateId { get; set; }
    }
}
