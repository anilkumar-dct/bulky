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
            _context.products.Include(u => u.Category);
            //you can also add multiple properties as well in above syntax given below
            //_context.products.Include(u => u.Category).Include(u => u.CategoryId);
        }
        public void Add(T item)
        {
            DbSet.Add(item);
        }
        //for getting the properties of category we used includeCategory in below method as parameter
        public T Get(Expression<Func<T, bool>> filter, string? includeCategory = null)
        {
            IQueryable<T> query = DbSet;
            query= query.Where(filter);
            if (!string.IsNullOrEmpty(includeCategory))
            {
                query = query.Include(includeCategory);
            }
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(string? includeCategory=null)
        {
           IQueryable<T> query = DbSet;
            if (!string.IsNullOrEmpty(includeCategory))
            {
                query = query.Include(includeCategory);
            }
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