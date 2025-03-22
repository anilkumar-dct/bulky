using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Bulky.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace Bulky.DataAccess.Repository.IRepository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        internal DbSet<T> DbSet;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
            this.DbSet =_context.Set<T>();
            //_db.Categories=Dbset;         
        }
        public void Add(T item)
        {
            DbSet.Add(item);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = DbSet;
            query= query.Where(filter);
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
           IQueryable<T> query = DbSet;
            return query.ToList();
        }

        public void Remove(T item)
        {
            DbSet.Remove(item);
        }

        public void RemoveRange(IEnumerable<T> items)
        {
            DbSet.RemoveRange(items);
        }

        public void Update(T item)
        {
            DbSet.Update(item);
        }
    }
}