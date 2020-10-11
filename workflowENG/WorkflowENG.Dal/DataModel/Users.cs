using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkflowENG.Dal.DataModel
{
    public class Users: BaseEntity
    { 
        public string Name { get; set; }
        public string Family { get; set; }
        public int RoleId { get; set; }
        public RolesForUsers roles { get; set; }
        public Guid GUID { get; set; }
    }
}
