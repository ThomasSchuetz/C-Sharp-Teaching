using System;

namespace Serialization
{
    internal static class Program
    {
        private static void Main()
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
