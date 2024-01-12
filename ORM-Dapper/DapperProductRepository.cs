using System;
using System.Data;
using Dapper;

namespace ORM_Dapper
{
	public class DapperProductRepository : IProductRepository
	{
        private readonly IDbConnection _connection;

        public DapperProductRepository(IDbConnection connection)
		{
            _connection = connection;
		}

        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("select * from products;");
        }

        public void CreateProduct(string newName, double newPrice, int newCategoryID)
        {
            _connection.Execute("insert into products (name, price, categoryid) " +
                "values (newname, newprice, newcategoryid);",
                new { newname = newName, newprice = newPrice, newcategoryid = newCategoryID});
        }

        public void CreateProduct(int newID, string newName, double newPrice, int newCategoryID, bool onSale, int stockLevel)
        {
            _connection.Execute("insert into products (productid, name, price, categoryid, onsale, stocklevel) " +
                "values (newname, newprice, newcategoryid);",
                new { newid = newID, newname = newName, newprice = newPrice, newcategoryid = newCategoryID, onsale = onSale, stocklevel = stockLevel });
        }

        
    }
}
/*
public int ProductID { get; set; }
public string Name { get; set; }
public double Price { get; set; }
public int CategoryID { get; set; }
public bool OnSale { get; set; }
public int StockLevel { get; set; }
*/