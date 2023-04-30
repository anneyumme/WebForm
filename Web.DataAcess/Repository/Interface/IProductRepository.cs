using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Models;

namespace Web.DataAccess.Repository.Interface
{
    public interface IProductRepository : IRepository<Product>
    {
        void update(Product product);
        void save();
    }
}
