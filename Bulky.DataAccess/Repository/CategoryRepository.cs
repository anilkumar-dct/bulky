using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models.Models;

namespace Bulky.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context):base(context) 
        {
            _context = context;
        }

        public object categories => throw new NotImplementedException();

        public   void Save()
        {
          _context.SaveChanges();
        }

     public   void Update(Category category)
        {
          _context.Update(category);
        }
    }
}
