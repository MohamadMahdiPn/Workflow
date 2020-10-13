using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowENG.Dal.DataModel;

namespace WorkflowENG.Dal.ViewModels
{
    public class BaseViewModel<T>
    {
        public T DataModel { get; set; }
        public IEnumerable<T> DataModels { get; set; }
    }
}
