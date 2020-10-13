using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowENG.Dal.DataModel;

namespace WorkflowENG.Dal.ViewModels
{
    public class UsersViewModel:BaseViewModel<Users>
    {
        public IEnumerable<RolesForUsers> Roles { get; set; }

    }
}
