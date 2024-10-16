using DBService.Models;

namespace ConsoleApp8
{
    internal class Program
    {
        private static OrderService _orderService;
        static void Main(string[] args)
        {
            _orderService = new OrderService();
            _orderService.EnsurePopulated();

            AddOrder();
            GetOrder();

        }
        static void AddOrder()
        {
            Order order = new Order()
            {
                Name = "Test",
                Address = "Kiev,Hrestchatik 23"
            };
            var product = _orderService.GetProduct(2);
            var product2 = _orderService.GetProduct(1);

            order.OrderLines.Add(new OrderLine
            { 
                ProductId = product.Id,
                Quantity = 2
            });
            order.OrderLines.Add(new OrderLine
            { 
                ProductId = product2.Id, 
                Quantity = 3 
            });
            _orderService.AddOrder(order);
        }
        static void GetOrder()
        {
            var currentOrder = _orderService.GetOrder(1);
            if (currentOrder != null)
            {
                Console.WriteLine(  currentOrder);
            }
        }
    }
}
