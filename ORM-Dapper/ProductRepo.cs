using System.Data;
using Dapper;

namespace ORM_Dapper;

public class ProductRepo : IProductRepo
{
    private readonly IDbConnection _connection;

    public ProductRepo(IDbConnection connection)
    {
        _connection = connection;
    }
    
    public IEnumerable<Product> GetAllProducts()
    {
        return _connection.Query<Product>("SELECT * FROM products;");
    }

    public void CreateProduct(string name, double price, int categoryID)
    {
        _connection.Execute(
            "INSERT INTO products (Name, Price, CategoryID) VALUES (@name, @price, @categoryID);",
            new { name, price, categoryID });
    }

    public void UpdateProductName(int productId, string newName)
    {
        _connection.Execute("UPDATE products SET Name = @newName WHERE ProductID = @productId;", new {productId, newName});
    }

    public void DeleteProduct(int productId)
    {
        _connection.Execute("DELETE FROM reviews WHERE ProductID = @productID;", new { productId });
        _connection.Execute("DELETE FROM sales WHERE ProductID = @productID;", new { productId });
        _connection.Execute("DELETE FROM products WHERE ProductID = @productID;", new { productId });
    }
}