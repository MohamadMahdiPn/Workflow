using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkflowENG.Dal.Repository
{
    public interface IPaperRepository<Tentity>
    {
        IQueryable<Tentity> GetAll();
        Tentity GetById(int Id);
        Tentity Get(Tentity tentity);
        bool Insert(Tentity tentity);
        void Update(Tentity tentity);
        void Delete(int Id);
        void Delete(Tentity tentity);
        bool Count(int Id);

    }
}
