using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkflowENG.Dal.DataModel
{
   public class RolesForUsers: BaseEntity
    {

        public string RoleName { get; set; }
        public int ParentId { get; set; }
        public ICollection<Users> Users { get; set; }
       // public ICollection<RolesForUsers> ParentRoles { get; set; }
    }
}
