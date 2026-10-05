namespace Part1_ProceduralToOOP
{
    internal class OrderLine
    {

        public Product Product { get; private set; } = null!;

        public int Quantity{ get; private set; }

        private void ValidateOrderLine(Product product, int quantity)
        {
            if (product is null)
                throw new ArgumentNullException(nameof(product));



            if (quantity <= 0)
                throw new ArgumentOutOfRangeException(nameof(quantity));

            

        }


        public OrderLine(Product product, int quantity)
        {

            ValidateOrderLine(product,quantity);

            Product = product;
            Quantity = quantity;
        }






    }
}
