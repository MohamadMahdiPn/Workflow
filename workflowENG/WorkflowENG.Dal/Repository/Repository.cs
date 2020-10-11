using System;
using System.Data.Entity;
using WorkflowENG.Dal.DataModel;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
namespace WorkflowENG.Dal.Repository
{
    public class Repository<Tentity>where Tentity : BaseEntity
    {
        private WFEDbContext context = new WFEDbContext();
        private readonly DbSet<Tentity> _dbset;

        public Repository()
        {
            _dbset = context.Set<Tentity>();
        }
        public virtual IQueryable<Tentity> GetAll(Expression<Func<Tentity, bool>> where = null)
        {
            IQueryable<Tentity> query = _dbset;
            if (where != null)
            {
                query = query.Where(where);
            }
            return query;
        }

        public virtual Tentity GetById(object Id)
        {
            return _dbset.Find(Id);
        }
        public virtual void Insert(Tentity entity, string UserCreator)
        {
            entity.CreateDate = DateTime.Now;
            _dbset.Add(entity);
        }
        public virtual void Update(Tentity entity)
        {
            entity.ModifiedDate = DateTime.Now;
            _dbset.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;

        }
        public virtual void Delete(Tentity entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                _dbset.Attach(entity);
            }
            _dbset.Remove(entity);
        }
        public virtual void Delete(object Id)
        {
            var entity = GetById(Id);
            Delete(entity);
        }
        public virtual void SoftDelete(object Id)
        {
            var entity = GetById(Id);
            entity.IsDeleted = true;
            Update(entity);
        }
        public virtual void Save()
        {
            context.SaveChanges();
        }
        public virtual void Dispose()
        {
            context.Dispose();
        }
    }
}
