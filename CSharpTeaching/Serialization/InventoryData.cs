namespace Serialization
{
    public static class InventoryData
    {
        public static Inventory GetData()
        {
            var inventory = new Inventory();
            inventory.AddArticle(1, new Article { Name = "Computer", Price = 500 });
            inventory.AddArticle(5, new Article { Name = "Phone", Price = 200 });
            inventory.AddArticle(10, new Article { Name = "Desk", Price = 1000 });
            inventory.AddArticle(11, new Article { Name = "Car", Price = 15000 });
            inventory.AddArticle(12, new Article { Name = "Chair", Price = 400 });

            return inventory;
        }
    }
}
