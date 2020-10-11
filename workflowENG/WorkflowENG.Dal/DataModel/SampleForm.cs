using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkflowENG.Dal.DataModel
{
    public class SampleForm: BaseEntity
    {
      
        public string Message { get; set; }
        public string Answer { get; set; }
        public ICollection<Flows> Flows { get; set; }
    }
}
