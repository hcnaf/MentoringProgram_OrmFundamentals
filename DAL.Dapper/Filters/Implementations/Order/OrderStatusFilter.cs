using DAL.Dapper.Models;

namespace DAL.Filters.Implementations.Order
{
    public class OrderStatusFilter: IFilter
    {
        private OrderStatus _orderStatus;

        public OrderStatusFilter(OrderStatus orderStatus)
        {
            _orderStatus = orderStatus;
        }

        public string GetEqualityStatement() => $"[Status] = {(int)_orderStatus}";
    }
}
