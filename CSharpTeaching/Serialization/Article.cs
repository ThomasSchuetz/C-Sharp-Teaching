namespace Serialization
{
    public class Article
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public override string ToString() => $"{Name}, with price of {Price}";
    }
}
