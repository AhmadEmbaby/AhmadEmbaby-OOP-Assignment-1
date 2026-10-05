namespace Part1_ProceduralToOOP
{
    internal class Product
    {

        public int Id { get; private set; }

        public string Name { get; private set; } = null!;

        public decimal Price{ get; private set; } 

        public int Stock{ get; private set; } 


        private void ValidateProduct(int id, string name, decimal price, int stock)
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException(nameof(id));


            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name can not be null or whitespaces", nameof(name));


            if (price<0)
                throw new ArgumentOutOfRangeException(nameof(price));

            if (stock<0)
                throw new ArgumentOutOfRangeException(nameof(stock));


        }



        public Product(int id, string name, decimal price, int stock)
        {
            ValidateProduct(id,name,price,stock);

            Id = id;
            Name = name;
            Price = price;
            Stock = stock;
        }

        public void DecreaseStock(int quantity) => Stock-=quantity;

    }
}
