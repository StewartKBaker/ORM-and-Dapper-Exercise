using System.Data;
using Dapper;

namespace ORM_Dapper;


public class DepartmentRepo : IDepartmentRepo
{
    private readonly IDbConnection _connection;

    public DepartmentRepo(IDbConnection connection)
    {
        _connection = connection;
    }
    
    public IEnumerable<Department> GetAllDepartments()
    {
        return _connection.Query<Department>("SELECT * FROM Departments;");
    }

    public void InsertDepartment(string newDepartmentName)
    {
        _connection.Execute("INSERT INTO Departments (Name) VALUES (@newDepartmentName)",
            new { newDepartmentName });
    }
}