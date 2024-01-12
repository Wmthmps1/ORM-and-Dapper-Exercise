using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace ORM_Dapper
{
    public class Program
    {

        public static bool ContinuePrompt()
        {
            bool validInput = false;
            bool continuePrompt = false;
            Console.WriteLine("Would you like to make another selection? yes or no");
            string input = Console.ReadLine();

            do
            {
                if (input.ToLower() == "yes" || input.ToLower() == "no")
                {
                    continuePrompt = (input.ToLower() == "yes") ? true : false;
                    validInput = true;
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid input: yes or no");
                }



            } while (validInput == false);

            return continuePrompt;
        }

        static void Main(string[] args)
        {
            bool validInput = false;
            bool anotherSelection = false;
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);
            var departmentRepo = new DapperDepartmentRepository(conn);
            var productRepo = new DapperProductRepository(conn);

            do
            {
                Console.WriteLine("Hello, what would you like to do?");
                Console.WriteLine("1. View all departments");
                Console.WriteLine("2. Create a new department");
                Console.WriteLine("3. View all products");
                Console.WriteLine("4. Create a new product");
                Console.WriteLine("Enter the number for what you would like to do: ");
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int selection) && selection <= 4 && selection >= 1)
                {

                    
                    switch (selection)
                    {
                        case 1:
                            var departments = departmentRepo.GetAllDepartments();
                            foreach (var department in departments)
                            {
                                Console.WriteLine($"{department.DepartmentID}, {department.Name}");
                            }
                            break;
                        case 2:
                            Console.WriteLine("What is the department ID number?");
                            var departmentID = int.Parse(Console.ReadLine());
                            Console.WriteLine("What is the department name?");
                            var departmentName = Console.ReadLine();
                            departmentRepo.InsertDepartment(departmentID, departmentName);
                            
                            break;
                        case 3:
                            var products = productRepo.GetAllProducts();
                            foreach (var product in products)
                            {
                                Console.WriteLine($"{product.ProductID},{product.Name}, {product.Price}," +
                                    $"{product.OnSale}, {product.CategoryID}, {product.StockLevel}");
                            }
                            break;
                        case 4:
                            
                            Console.WriteLine("What is the product ID?");
                            var productID = int.Parse(Console.ReadLine());

                            Console.WriteLine("What is the product name?");
                            var productName = Console.ReadLine();

                            Console.WriteLine("What is the price?");
                            var price = double.Parse(Console.ReadLine());

                            Console.WriteLine("What is the category ID?");
                            var categoryID = int.Parse(Console.ReadLine());

                            Console.WriteLine("Is it on sale? Yes or No");
                            bool onSale = false;

                            if (Console.ReadLine().ToLower() == "yes")
                            {
                                onSale = true;

                            } else if (Console.ReadLine().ToLower() == "no")
                            {
                                onSale = false;
                            }

                            Console.WriteLine("How many are in stock?");
                            var stock = int.Parse(Console.ReadLine());
                            productRepo.CreateProduct(productID, productName, price, categoryID, onSale, stock);

                            break;
                        default:
                            break;

                    }
                    validInput = true;
                    break;

                }
                else
                {
                    Console.WriteLine("Enter a valid input");
                }
            } while (validInput == false || anotherSelection == true);
        }
    }
}
