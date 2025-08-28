using System.Globalization;
using Shop.Entities;
using Shop.Entities.Enums;

namespace Shop {
    internal class Program {
        static void Main(string[] args) 
            {
            Console.WriteLine("Enter cliente data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime birthData = DateTime.Parse(Console.ReadLine());
            DateTime hourMoment = DateTime.Now;

            Client client = new Client(name,email,birthData);

            Console.WriteLine("Enter order data:");
            Console.Write("Status: ");
            OrderStatus orderStatus = Enum.Parse<OrderStatus>(Console.ReadLine());

            Order order = new Order(hourMoment,orderStatus,client);

            Console.Write("How many items to this order? ");
            int qttItems = int.Parse(Console.ReadLine());

            for (int i = 1; i <= qttItems; i++) 
            {
                Console.WriteLine("Enter #{0} item data:", i);
                Console.Write("Product name: ");
                string productName= Console.ReadLine();
                Console.Write("Product price: ");
                double productPrice = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);

                Product product = new Product(productName, productPrice);


                Console.Write("Quantity: ");
                int productQuantity = int.Parse(Console.ReadLine());


                OrderItem orderItem = new OrderItem(productQuantity,productPrice,product);
                
                order.addItem(orderItem);
            }
            Console.WriteLine();
            Console.WriteLine(order);
        }
    }
}