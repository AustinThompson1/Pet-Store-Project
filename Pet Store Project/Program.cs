

using System.ComponentModel.Design;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.DependencyInjection;

namespace Pet_Store_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var services = CreateServiceCollection();

            var productLogic = services.GetService<IProductLogic>();

            string userInput = displayMenuAndGetInput();

            while (userInput.ToLower() != "exit")
            { 
                if (userInput == "1")
                {
                    var dogLeash = new DogLeash();

                    Console.WriteLine("Creating a dog leash...");

                    Console.Write("Enter the material the leash is made out of: ");
                    dogLeash.Material = Console.ReadLine();

                    Console.Write("Enter the length in inches: ");
                    dogLeash.LengthInInches = int.Parse(Console.ReadLine());

                    Console.Write("Enter the name of the leash: ");
                    dogLeash.Name = Console.ReadLine();

                    Console.Write("Give the product a short description: ");
                    dogLeash.Description = Console.ReadLine();

                    Console.Write("Give the product a price: ");
                    dogLeash.Price = decimal.Parse(Console.ReadLine());

                    Console.Write("How many products do you have on hand? ");
                    dogLeash.Quantity = int.Parse(Console.ReadLine());

                    productLogic.AddProduct(dogLeash);
                    Console.WriteLine("Added dog leash");
                }
                if (userInput == "2")
                {
                    Console.WriteLine("What is the name of dog leash you'd like to view? ");
                    var dogLeashName = Console.ReadLine();
                    var dogLeash = productLogic.GetDogLeashByName(dogLeashName);
                    Console.WriteLine(JsonSerializer.Serialize(dogLeash));
                    Console.WriteLine();
                }
                if (userInput == "3")
                {
                    Console.WriteLine($"Showing in stock products....");
                    var inStock = productLogic.GetOnlyInStockObjects();
                    foreach (var item in inStock)
                    {
                        Console.WriteLine(item);
                    }
                    Console.WriteLine();
                }
                if (userInput == "4")
                {
                    Console.WriteLine("Showing total price of inventory");
                    var totalPrice = productLogic.GetTotalPriceOfInventory();
                    Console.WriteLine(totalPrice);
                    Console.WriteLine();
                }

             userInput = displayMenuAndGetInput();

            }
            static string displayMenuAndGetInput()
            {
                Console.WriteLine("Press 1 to add a product");
                Console.WriteLine("Press 2 to view a Dog Leash Product");
                Console.WriteLine("Press 3 to view all in stock items");
                Console.WriteLine("Press 4 to get total price of inventory");
                Console.WriteLine("Type 'exit' to quit");

                return Console.ReadLine();
            }
            static IServiceProvider CreateServiceCollection()
            {
                return new ServiceCollection()
                    .AddTransient<IProductLogic,ProductLogic>()
                    .BuildServiceProvider();

            }
        }
    }
}
