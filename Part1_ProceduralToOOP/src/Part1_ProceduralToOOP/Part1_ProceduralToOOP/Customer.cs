namespace Part1_ProceduralToOOP
{
    internal class Customer
    {

        public int Id { get; private set; } 

        public string Name { get; private set; } = null!;

        public string Email{ get; private set; } = null!;

        public string City{ get; private set; } = null!;

        public bool IsVip{ get;private set; }

        


        private void ValidateCustomer(int id, string name, string email, string city)
        {
            if(id <0)
            throw new ArgumentOutOfRangeException(nameof(id));


            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name can not be null or whitespaces",nameof(name));


            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email can not be null or whitespaces", nameof(email));

            if (string.IsNullOrWhiteSpace(city))
                throw new ArgumentException("City can not be null or whitespaces", nameof(city));


        }
        

        public Customer(int id, string name, string email, string city, bool isVip )
        {

            ValidateCustomer(id,name, email, city);

            Id = id;
            Name = name;
            Email = email;
            City = city;
            IsVip = isVip;

        }



    }
}
