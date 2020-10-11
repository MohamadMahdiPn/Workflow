using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowENG.Dal.DataModel;

namespace WorkflowENG.Dal.Repository
{
    public class UnitWork
    {
        private WFEDbContext context = new WFEDbContext();
        private Repository<Flows> FlowsRepository;
        private Repository<Users> UsersRepository;
        private Repository<RolesForUsers> RoleForUsersRepository;
        private Repository<SampleForm> SampleRepository;


        public Repository<Flows> Flows
        {
            get
            {
                if (FlowsRepository == null)
                {
                    FlowsRepository = new Repository<Flows>();
                }
                return FlowsRepository;
            }
        }
        public Repository<Users> Users
        {
            get
            {
                if (UsersRepository == null)
                {
                    UsersRepository = new Repository<Users>();
                }
                return UsersRepository;
            }
        }
        public Repository<RolesForUsers> Role
        {
            get
            {
                if (RoleForUsersRepository == null)
                {
                    RoleForUsersRepository = new Repository<RolesForUsers>();
                }
                return RoleForUsersRepository;
            }
        } 
        public Repository<SampleForm> Form
        {
            get
            {
                if (SampleRepository == null)
                {
                    SampleRepository = new Repository<SampleForm>();
                }
                return SampleRepository;
            }
        }
    }
}
