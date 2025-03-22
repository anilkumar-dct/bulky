using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bulky.Models;
using Bulky.Models.Models;

namespace Bulky.DataAccess.Repository.IRepository
{
    public interface IProductsRepository:IRepository<Products>
    {
        object categories { get; }

        void Update(Category category);
        void Save();
    }
}
