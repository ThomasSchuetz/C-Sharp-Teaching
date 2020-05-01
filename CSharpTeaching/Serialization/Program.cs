using System;

namespace Serialization
{
    static class Program
    {
        static void Main()
        {
            var inventory = InventoryData.GetData();

            inventory.Serialize("inventory.xml");

            var deserializedInventory = Inventory.Deserialize("inventory.xml");

            inventory.Print();
            Console.WriteLine();
            deserializedInventory.Print();

            Console.ReadLine();
        }
    }
}
