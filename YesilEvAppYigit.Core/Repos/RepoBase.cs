using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesilEvAppYigit.Core.Interfaces;

namespace YesilEvAppYigit.Core.Repos
{
    public abstract class RepoBase<TContext, TEntity> :
        ISelectableRepo<TEntity>,
        IUpdatableRepo<TEntity>,
        IInsertableRepo<TEntity>,
        IDeletableRepo<TEntity>
        where TEntity : class
        where TContext : DbContext, new()
    {

        private readonly TContext _context;

        public RepoBase(TContext context)
        {
            _context = context;
            _context.Configuration.LazyLoadingEnabled=false;
        }

        public RepoBase()
        {
            _context = new TContext();
        }

        public TEntity Add(TEntity item)
        {
            return _context.Set<TEntity>().Add(item);
        }

        public List<TEntity> AddRange(List<TEntity> items)
        {
            return _context.Set<TEntity>().AddRange(items).ToList();
        }

        public TEntity Delete(TEntity item)
        {
            return _context.Set<TEntity>().Remove(item);
        }

        public List<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public TEntity GetByID(object ID)
        {
            return _context.Set<TEntity>().Find(ID);
        }
        public void Update(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.Set<TEntity>().Attach(item);
        }
        public void Update(TEntity item,int ID)
        {
            _context.Entry(item).State = EntityState.Modified;
            var entity = GetByID(ID);
            if (entity == null)
            {
                return;
            }
            _context.Entry(entity).CurrentValues.SetValues(item);
        }

        public void MySaveChanges()
        {
            _context.SaveChanges();
        }

        public List<TEntity> GetBy(Func<TEntity, bool> whereCondition)
        {
            return _context.Set<TEntity>().Where(whereCondition).ToList();
        }

        
    }
}
