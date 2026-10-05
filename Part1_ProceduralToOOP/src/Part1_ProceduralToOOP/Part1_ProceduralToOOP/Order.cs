namespace Part1_ProceduralToOOP
{
    internal class Order
    {
        public int Id { get; private set; }
        public Customer Customer{ get; private set; }
        public List<OrderLine> OrderLinesList { get; private set; } = null!;

        public bool IsPaid{ get; private set; }

        public Order(int id,Customer customer)
        {
            Id = id;
            Customer = customer;
            OrderLinesList = [];
        }





        public void AddOrderLine(OrderLine orderLine)
        {
            if (IsPaid)
                throw new InvalidOperationException("You can NOT add aline to a paid order");

            if (orderLine.Product.Stock < orderLine.Quantity)
                throw new InvalidOperationException("There is NO enough stock");

            orderLine.Product.DecreaseStock(orderLine.Quantity);

            OrderLinesList.Add(orderLine);
        }

        public decimal CalculateOrderTotal()
        {
            decimal orderTotal = 0;

            foreach (OrderLine orderLine in OrderLinesList)
            {
                orderTotal += orderLine.Product.Price * orderLine.Quantity;
            }

            if (Customer.IsVip)
                orderTotal *= 0.9m;  //discount 10% 

            return orderTotal;
        }
        public void MarkAsPaid()
        {
            if (OrderLinesList.Count == 0)
                throw new InvalidOperationException("You Can Not pay an empty order");

            IsPaid = true;
        }





    }
}
