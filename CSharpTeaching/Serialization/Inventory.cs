using System;
using System.Collections.Generic;

namespace Serialization
{
    public class Inventory
    {
        private readonly Dictionary<uint, Article> articles = new Dictionary<uint, Article>();

        public void AddArticle(uint id, Article article) => articles[id] = article;

        public void Print()
        {
            foreach (var item in articles)
            {
                Console.WriteLine($"ID: {item.Key}, {item.Value}");
            }
        }

        public static Inventory Deserialize(string filename)
        {
            /*
             * 
             * Your code belongs here!
             * 
             */
            throw new NotImplementedException();
        }

        public void Serialize(string filename)
        {
            /*
             * 
             * Your code belongs here!
             * 
             */
        }
    }
}
