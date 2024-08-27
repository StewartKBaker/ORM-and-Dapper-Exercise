using System.Data;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace ORM_Dapper
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);

            //var departmentRepo = new DepartmentRepo(conn);

            // var departments = departmentRepo.GetAllDepartments();
            //
            // foreach (var department in departments)
            // {
            //     Console.WriteLine($"ID: {department.DepartmentID} Name: {department.Name}");
            // }

            var prodRepo = new ProductRepo(conn);
            
            //prodRepo.CreateProduct("Game", 55.00, 8 );
            //prodRepo.UpdateProductName(942,"Warframe");
            //prodRepo.DeleteProduct(942);

            var products = prodRepo.GetAllProducts();

            foreach (var product in products)
            {
                Console.WriteLine($"ID: {product.ProductID} | Name: {product.Name} | Price: {product.Price} | Category ID: {product.CategoryID} | On Sale: {product.OnSale} | Stock Level : {product.StockLevel}");
            }
        }
    }
}
