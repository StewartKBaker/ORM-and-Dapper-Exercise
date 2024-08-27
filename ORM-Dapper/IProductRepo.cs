namespace ORM_Dapper;

public interface IProductRepo
{
    public IEnumerable<Product> GetAllProducts();
    public void CreateProduct(string name, double price, int categoryID);
    public void UpdateProductName(int productId, string newName);
    public void DeleteProduct(int productId);
}