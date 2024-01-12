using System;
namespace ORM_Dapper
{
	public interface IProductRepository
	{
        public IEnumerable<Product> GetAllProducts();
        public void CreateProduct(int newID, string newName, double newPrice, int newCategoryID, bool onSale, int stockLevel);
    }
}

/*public int ProductID { get; set; }
		public string Name { get; set; }
		public double Price { get; set; }
		public int CategoryID { get; set; }
		public bool OnSale { get; set; }
		public int StockLevel { get; set; } */