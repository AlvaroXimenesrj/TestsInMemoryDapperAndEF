namespace InMemoryDbSample.Model
{
    public class Product
    {
        public Product(string name,
                       bool active)
        {
            Name = name;
            Active = active;

        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public bool Active { get; private set; }

        public static IEnumerable<Product> CreateProducts()
        {
            var products = new List<Product>()
            {
                new Product("Product 1", true),
                new Product("Product 2", true),
                new Product("Product 3", true),
                new Product("Product 4", false),
                new Product("Product 5", false)
            };

            products.AddRange(products);

            return products;


        }

        protected Product() { }
    }
}
