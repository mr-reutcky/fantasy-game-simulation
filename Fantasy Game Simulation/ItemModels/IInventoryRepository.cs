namespace Fantasy_Game_Simulation.ItemModels {
    public interface IInventoryRepository {
        void AddItem(Item item);
        void RemoveItem(string itemName);
        IEnumerable<Item> GetItems();
        Item FindItemByName(string name);
    }
}
