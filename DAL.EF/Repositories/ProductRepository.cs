using DAL.EF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Repositories
{
    public class ProductRepository
    {

        private readonly StoreContext _shopContext;

        public ProductRepository(StoreContext shopContext)
        {
            _shopContext = shopContext;
        }

        public async Task Create(Product entity)
        {
            await _shopContext.Products.AddAsync(entity);
        }

        public async Task<Product> Select(Guid id)
        {
            return await _shopContext.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IList<Product>> Fetch()
        {
            return await _shopContext.Products.AsNoTracking().ToListAsync();
        }

        public void Update(Product entity)
        {
            _shopContext.Products.Update(entity);
        }

        public void Delete(Product entity)
        {
            _shopContext.Products.Remove(entity);
        }
    }
}
