using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Bulky.Models.Models;

namespace Bulky.DataAccess.Repository
{
    public class ProductsRepository : Repository<Products>, IProductsRepository
    {
        private ApplicationDbContext _context;
        public ProductsRepository(ApplicationDbContext context):base(context) 
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
