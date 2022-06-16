namespace DAL.Dapper.Models
{
    public class Order
    {
        public Order()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; }
        public OrderStatus Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Guid ProductId { get; set; }
    }

    public enum OrderStatus
    {
        NotStarted,
        Loading,
        InProgress,
        Arrived,
        Unloading,
        Cancelled,
        Done
    }
}
