using System.Runtime.Serialization;

namespace Serialization
{
    [DataContract]
    public class Article
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public decimal Price { get; set; }

        public override string ToString() => $"{Name}, with price of {Price}";
    }
}
