using Shop.Entities.Enums;
using System.Globalization;
using System.Text;

namespace Shop.Entities {
    internal class Order {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public Client Client { get; set; }

        public Order()
        {
        }

        public Order(DateTime moment, OrderStatus status, Client client) 
        {
            Moment = moment;
            Status = status;
            Client = client;
        }

        public void addItem(OrderItem item)
        {
            Items.Add(item);
        }
        public void removeItem(OrderItem item) 
        { 
            Items.Remove(item);
        }

        public double Total() {
            double sum = 0.0;
            foreach (OrderItem item in Items) {
                sum += item.subTotal();
            }
            return sum;
        }

        public override string ToString() { 
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("ORDER SUMARY:");
            sb.Append("Order moment: ");
            sb.AppendLine(Moment.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.Append("Order status: ");
            sb.AppendLine(Status.ToString());
            sb.Append("Client: ");
            sb.Append(Client.Name);
            sb.Append(" (");
            sb.Append(Client.BirthDate.ToString("dd/MM/yyyy"));
            sb.Append(") - ");
            sb.AppendLine(Client.Email);
            sb.AppendLine("Order Items:");
            foreach (OrderItem item in Items) {
                sb.Append(item.product.Name+", $");
                sb.Append(item.product.Price.ToString("F2", CultureInfo.InvariantCulture));
                sb.Append(", Quantity: ");
                sb.Append(item.Quantity);
                sb.Append(", Subtotal: $");
                sb.AppendLine(item.subTotal().ToString("F2",CultureInfo.InvariantCulture));
            }
            sb.Append("Total price: $");
            sb.Append(Total().ToString("F2", CultureInfo.InvariantCulture));
            return sb.ToString();
        }
    }
}
