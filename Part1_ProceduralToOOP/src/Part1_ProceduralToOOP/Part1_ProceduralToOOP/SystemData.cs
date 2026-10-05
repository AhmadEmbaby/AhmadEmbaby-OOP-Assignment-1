namespace Part1_ProceduralToOOP
{
    internal class SystemData
    {
        public List<Customer> CustomersList { get; private set; } = null!;
        public List<Product> ProductsList { get; private set; } = null!;
        public List<Order> OrdersList { get; private set; } = null!;

        public SystemData()
        {
            CustomersList = [];
            ProductsList = [];
            OrdersList = [];
        }


        public  void AddCustomer(Customer customer) => CustomersList.Add(customer);


        public void AddProduct(Product product) => ProductsList.Add(product);

        public void AddOrder(Order order) => OrdersList.Add(order);

        
        public Customer? FindCustomerById(int id)
        {

            if (id < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }
            foreach (var customer in CustomersList)
            {
                if (customer.Id == id)
                    return customer;

            }
            return null;
        }

        
        public Product? FindProductById(int id)
        {

            if (id < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }
            foreach (var product in ProductsList)
            {
                if (product.Id == id)
                    return product;

            }
            return null;
        }

        public Order? FindOrderById(int id)
        {

            if (id < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }
            foreach (var order in OrdersList)
            {
                if (order.Id == id)
                    return order;

            }
            return null;
        }


        public decimal CalculateTotalSales()
        {
            decimal totalSales=0;


            foreach (var order in OrdersList)
            {
                if(order.IsPaid)
                {
                    totalSales += order.CalculateOrderTotal();
                }

            }


            return totalSales;
        }





        public void PrintCustomers()
        {
            if (CustomersList.Count == 0)
            {
                Console.WriteLine("Customers list is empty");
                return;
            }

            foreach (var customer in CustomersList)
            {
                Console.WriteLine(
                    $"ID: {customer.Id}, Name: {customer.Name}, Email: {customer.Email}, City: {customer.City}, VIP: {customer.IsVip}");
            }
        }
        public void PrintProducts()
        {
            if (ProductsList.Count == 0)
            {
                Console.WriteLine("Products list is empty");
                return;
            }


            foreach (var product in ProductsList)
            {
                Console.WriteLine(
                    $"Id: {product.Id}, Name: {product.Name}, Price: {product.Price}, Stock: {product.Stock}");
            }
        }

        public void PrintOrder(Order order)
        {

            Console.WriteLine($"Order Id: {order.Id}");
            Console.WriteLine($"Customer: {order.Customer.Name}");
            Console.WriteLine($"Paid: {order.IsPaid}");

            if (order.OrderLinesList.Count == 0)
            {
                Console.WriteLine("Order lines list is empty");
            }
            else
            {
                foreach (var orderLine in order.OrderLinesList)
                {
                    Console.WriteLine(
                        $"Product: {orderLine.Product.Name}, Quantity: {orderLine.Quantity}, Price: {orderLine.Product.Price}");
                }
            }

            Console.WriteLine($"Total: {order.CalculateOrderTotal()}");

        }

        public void PrintAllOrders()
        {
            if (OrdersList.Count == 0)
            {
                Console.WriteLine("Orders list is empty");
                return;
            }

            foreach (var order in OrdersList)
            {
                PrintOrder(order);
                Console.WriteLine();
            }
        }



    }
}
