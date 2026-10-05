namespace Part1_ProceduralToOOP
{
    internal class Menu
    {
        private readonly SystemData _systemData;

        public Menu(SystemData systemData)
        {
            _systemData = systemData;
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("\n1. Add Customer");
                Console.WriteLine("2. Add Product");
                Console.WriteLine("3. Create Order");
                Console.WriteLine("4. Add Order Line");
                Console.WriteLine("5. Pay Order");
                Console.WriteLine("6. Print Customers");
                Console.WriteLine("7. Print Products");
                Console.WriteLine("8. Print Order");
                Console.WriteLine("9. Print All Orders");
                Console.WriteLine("10. Print Total Sales");
                Console.WriteLine("11. Exit\n");
                Console.Write("Choose: ");

                string? choice = Console.ReadLine();

                try
                {
                    if (choice == "1")
                    {
                        AddCustomer();
                    }
                    else if (choice == "2")
                    {
                        AddProduct();
                    }
                    else if (choice == "3")
                    {
                        CreateOrder();
                    }
                    else if (choice == "4")
                    {
                        AddOrderLine();
                    }
                    else if (choice == "5")
                    {
                        PayOrder();
                    }
                    else if (choice == "6")
                    {
                        _systemData.PrintCustomers();
                    }
                    else if (choice == "7")
                    {
                        _systemData.PrintProducts();
                    }
                    else if (choice == "8")
                    {
                        PrintOrder();
                    }
                    else if (choice == "9")
                    {
                        _systemData.PrintAllOrders();
                    }
                    else if (choice == "10")
                    {
                        PrintTotalSales();
                    }
                    else if (choice == "11")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void AddCustomer()
        {
            Console.Write("Customer Id: ");
            int id = int.Parse(Console.ReadLine()!);

            Console.Write("Name: ");
            string name = Console.ReadLine()!;

            Console.Write("Email: ");
            string email = Console.ReadLine()!;

            Console.Write("City: ");
            string city = Console.ReadLine()!;

            Console.Write("Is VIP? (true/false): ");
            bool isVip = bool.Parse(Console.ReadLine()!);

            Customer customer = new(id, name, email, city, isVip);

            _systemData.AddCustomer(customer);

            Console.WriteLine("Customer added");
        }

        private void AddProduct()
        {
            Console.Write("Product Id: ");
            int id = int.Parse(Console.ReadLine()!);

            Console.Write("Name: ");
            string name = Console.ReadLine()!;

            Console.Write("Price: ");
            decimal price = decimal.Parse(Console.ReadLine()!);

            Console.Write("Stock: ");
            int stock = int.Parse(Console.ReadLine()!);

            Product product = new(id, name, price, stock);

            _systemData.AddProduct(product);

            Console.WriteLine("Product added");
        }

        private void CreateOrder()
        {
            Console.Write("Order Id: ");
            int orderId = int.Parse(Console.ReadLine()!);

            Console.Write("Customer Id: ");
            int customerId = int.Parse(Console.ReadLine()!);

            Customer? customer = _systemData.FindCustomerById(customerId);

            if (customer is null)
            {
                Console.WriteLine("Customer not found");
                return;
            }

            Order order = new(orderId, customer);

            _systemData.AddOrder(order);

            Console.WriteLine("Order created");
        }

        private void AddOrderLine()
        {
            Console.Write("Order Id: ");
            int orderId = int.Parse(Console.ReadLine()!);

            Console.Write("Product Id: ");
            int productId = int.Parse(Console.ReadLine()!);

            Console.Write("Quantity: ");
            int quantity = int.Parse(Console.ReadLine()!);

            Order? order = _systemData.FindOrderById(orderId);
            Product? product = _systemData.FindProductById(productId);

            if (order is null)
            {
                Console.WriteLine("Order not found");
                return;
            }

            if (product is null)
            {
                Console.WriteLine("Product not found");
                return;
            }

            OrderLine orderLine = new(product, quantity);

            order.AddOrderLine(orderLine);

            Console.WriteLine("Order line added");
        }

        private void PayOrder()
        {
            Console.Write("Order Id: ");
            int orderId = int.Parse(Console.ReadLine()!);

            Order? order = _systemData.FindOrderById(orderId);

            if (order is null)
            {
                Console.WriteLine("Order not found");
                return;
            }

            order.MarkAsPaid();

            Console.WriteLine("Order paid");
        }

        private void PrintOrder()
        {
            Console.Write("Order Id: ");
            int orderId = int.Parse(Console.ReadLine()!);

            Order? order = _systemData.FindOrderById(orderId);

            if (order is null)
            {
                Console.WriteLine("Order not found");
                return;
            }

            _systemData.PrintOrder(order);
        }

        private void PrintTotalSales()
        {
            decimal totalSales = _systemData.CalculateTotalSales();

            Console.WriteLine($"Total Sales: {totalSales}");
        }
    }
}