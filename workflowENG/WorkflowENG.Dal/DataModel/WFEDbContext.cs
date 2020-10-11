using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkflowENG.Dal.DataModel
{
    public class WFEDbContext:DbContext
    {
        public WFEDbContext():base("DefaultConnection")
        {

        }
        public DbSet<Users> Users { get; set; }
        public DbSet<RolesForUsers> RolesForUsers { get; set; }
        public DbSet<Flows> Flows { get; set; }
        public DbSet<SampleForm> SampleForms { get; set; }
    }
}
