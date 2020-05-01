using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace Serialization
{
    [DataContract]
    public class Inventory
    {
        [DataMember]
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
            var serializer = new DataContractSerializer(typeof(Inventory));

            var file = new FileStream(filename, FileMode.Open);
            var result = (Inventory)serializer.ReadObject(file);
            file.Close();

            return result;
        }

        public void Serialize(string filename)
        {
            var serializer = new DataContractSerializer(typeof(Inventory));
            var settings = new XmlWriterSettings
            {
                Indent = true
            };

            var file = new FileStream(filename, FileMode.Create);
            var writer = XmlWriter.Create(file, settings);

            serializer.WriteObject(writer, this);

            writer.Close();
            file.Close();
        }
    }
}
