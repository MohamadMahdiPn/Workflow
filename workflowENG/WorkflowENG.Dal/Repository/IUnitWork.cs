using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowENG.Dal.DataModel;

namespace WorkflowENG.Dal.Repository
{
    public interface IUnitWork
    {
        Repository<Flows> Flows { get; }
        Repository<Users> Users { get; }
        Repository<RolesForUsers> Role { get; }
        Repository<SampleForm> Form { get; }

    }
}
