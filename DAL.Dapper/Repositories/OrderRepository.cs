using DAL.Dapper.Models;
using DAL.Filters;
using Dapper;
using System.Data.SqlClient;

namespace DAL.Dapper.Repositories
{
    public class OrderRepository
    {
        private const string InsertExpression = "INSERT INTO Orders (Id, Status, CreatedDate, UpdatedDate, ProductId) " +
                                               "VALUES (@Id, @Status, @CreatedDate, @UpdatedDate, @ProductId)";
        private const string SelectExpression = "SELECT * FROM Orders WHERE Id = @id";
        private const string UpdateExpression = "UPDATE Orders SET Status=@Status, CreatedDate=@CreatedDate, UpdatedDate=@UpdatedDate, ProductId=@ProductId WHERE Id=@Id";
        private const string DeleteExpression = "DELETE FROM [Orders]";

        private const string FetchExpression = "SELECT * FROM Orders";

        private readonly string _connectionString;

        public OrderRepository(string connectionString = AppSettings.ConnectionString)
        {
            _connectionString = connectionString;
        }

        public async Task Create(Order entity)
        {
            await using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync(InsertExpression, entity);
        }

        public async Task<Order> Select(Guid id)
        {
            await using var connection = new SqlConnection(_connectionString);
            var order = await connection.QueryFirstOrDefaultAsync<Order>(SelectExpression, new { Id = id });
            return order;
        }

        public async Task<IList<Order>> Fetch()
        {
            return await Fetch();
        }

        public async Task Update(Order entity)
        {
            await using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync(UpdateExpression, entity);
        }

        public async Task Delete(Order entity)
        {
            await using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync(DeleteExpression, new { Id = entity.Id });
        }

        public async Task<IList<Order>> Fetch(params IFilter[] filters)
        {
            await using var connection = new SqlConnection(_connectionString);
            var filterBuilder = new FilterBuilder().Add(filters);
            var products = await connection.QueryAsync<Order>(FetchExpression + filterBuilder.BuildWhereExpression());
            return products.ToList();
        }

        public async Task BulkDelete(params IFilter[] filters)
        {
            await using var connection = new SqlConnection(_connectionString);
            var filterBuilder = new FilterBuilder().Add(filters);
            await connection.ExecuteAsync(DeleteExpression + filterBuilder.BuildWhereExpression());
        }
    }
}
