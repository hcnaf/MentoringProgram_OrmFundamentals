using DAL.EF.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

#pragma warning disable

namespace DAL.EF.Repositories
{
    public class OrderRepository
    {
        private readonly StoreContext _shopContext;

        public OrderRepository(StoreContext shopContext)
        {
            _shopContext = shopContext;
        }

        public async Task Create(Order entity)
        {
            await _shopContext.Orders.AddAsync(entity);
        }

        public async Task<Order> Select(Guid id)
        {
            return await _shopContext.Orders.AsNoTracking().FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<IList<Order>> Fetch()
        {
            return await _shopContext.Orders.AsNoTracking().ToListAsync();
        }

        public void Update(Order entity)
        {
            _shopContext.Orders.Update(entity);
        }

        public void Delete(Order entity)
        {
            _shopContext.Orders.Remove(entity);
        }

        public async Task<IList<Order>> Fetch(Predicate<Order> filter)
        {
            return await _shopContext.Orders
                .Where(x => filter(x))
                .AsNoTracking()
                .ToListAsync();
        }

        public void BulkDelete(Expression<Func<Order, bool>> filter)
        {
            var ordersToDelete = _shopContext.Orders
                .Where(filter);

            _shopContext.Orders.RemoveRange(ordersToDelete);
        }
    }
}
