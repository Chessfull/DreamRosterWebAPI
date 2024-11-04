using DreamRosterBuilding.Data.Context;
using DreamRosterBuilding.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DreamRosterBuilding.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity:BaseEntity
    {
        private readonly DreamRosterBuildingDbContext _context;
        private readonly DbSet<TEntity> _dbSet;


        public Repository(DreamRosterBuildingDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
           entity.CreatedDate = DateTime.Now;
           entity.ModifiedDate = DateTime.Now;
           _dbSet.Add(entity);

        }

        public void Delete(TEntity entity, bool softDelete = true)
        {
            if (softDelete)
            {
                entity.IsDeleted = true;
                entity.ModifiedDate = DateTime.Now;
                _dbSet.Update(entity);
            }
            else // -> Harddelete for optional ( I need this while updation many to many tables like playerpositions,skills )
            {
                _dbSet.Remove(entity);
            }
        }

        public void DeleteById(int id)
        {
            var entity = _dbSet.Find(id);
            entity.ModifiedDate= DateTime.Now;
            Delete(entity);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> linqQuery)
        {
            return _dbSet.FirstOrDefault(linqQuery);
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> linqQuery = null) // -> IQuaryable for Eager loading and able to use with queries like Select etc.
        {
            return linqQuery is null ? _dbSet : _dbSet.Where(linqQuery);
        }

        public TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Update(TEntity entity)
        {
            entity.ModifiedDate=DateTime.Now;
            _dbSet.Update(entity);
        }
    }
}
