namespace DAL.Dapper.Models
{
    public class Product
    {
        public Product()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }
    }
}
