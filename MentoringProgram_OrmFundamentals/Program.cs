using DAL.EF;
using ProductEF = DAL.EF.Models.Product;
using OrderEF = DAL.EF.Models.Order;
using ProductDapper = DAL.Dapper.Models.Product;
using OrderDapper = DAL.Dapper.Models.Order;
using ProductRepositoryEF = DAL.EF.Repositories.ProductRepository;
using OrderRepositoryEF = DAL.EF.Repositories.OrderRepository;
using ProductRepositoryDapper = DAL.Dapper.Repositories.ProductRepository;
using OrderRepositoryDapper = DAL.Dapper.Repositories.OrderRepository;

#pragma warning disable

#region EF
var context = new StoreContext();

var productRepositoryEF = new ProductRepositoryEF(context);
var orderRepositoryEF = new OrderRepositoryEF(context);

productRepositoryEF.Create(new ProductEF() { Name = "Product1", Description = "ShortDescr", Height = 1, Length = 2, Weight = 3, Width = 4 });

productRepositoryEF.Create(new ProductEF() { Name = "Product2", Description = "Descr", Height = 3, Length = 4, Weight = 5, Width = 6 });

productRepositoryEF.Create(new ProductEF() { Name = "Product3", Description = "Descr3", Height = 3, Length = 4, Weight = 5, Width = 6 });

context.SaveChanges();

var firstProduct = (await productRepositoryEF.Fetch()).FirstOrDefault();
var order = new OrderEF() { ProductId = firstProduct.Id, CreatedDate = DateTime.UtcNow, Status = DAL.EF.Models.OrderStatus.Loading };
orderRepositoryEF.Create(order);

context.SaveChanges();

//orderRepository.BulkDelete(x => true);

context.SaveChanges();

#endregion

#region Dapper

var productRepositoryDapper = new ProductRepositoryDapper();
var orderRepositoryDapper = new OrderRepositoryDapper();

await productRepositoryDapper.Create(new ProductDapper() { Name = "Product1", Description = "ShortDescr", Height = 1, Length = 2, Weight = 3, Width = 4 });

await productRepositoryDapper.Create(new ProductDapper() { Name = "Product2", Description = "Descr", Height = 3, Length = 4, Weight = 5, Width = 6 });

await productRepositoryDapper.Create(new ProductDapper() { Name = "Product3", Description = "Descr3", Height = 3, Length = 4, Weight = 5, Width = 6 });

var firstProductDapper = (await productRepositoryEF.Fetch()).FirstOrDefault();
var orderDapper = new OrderDapper() { ProductId = firstProductDapper.Id, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow, Status = DAL.Dapper.Models.OrderStatus.Loading };
await orderRepositoryDapper.Create(orderDapper);

#endregion
