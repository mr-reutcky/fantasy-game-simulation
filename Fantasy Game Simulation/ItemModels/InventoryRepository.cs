namespace Fantasy_Game_Simulation.ItemModels {
    public class InventoryRepository : IInventoryRepository {
        private readonly List<Item> _items = new List<Item>();

        public void AddItem(Item item) {
            _items.Add(item);
        }
        public void RemoveItem(string itemName) {
            _items.RemoveAll(i => i.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));
        }
        public IEnumerable<Item> GetItems() {
            return _items;
        }
        public Item FindItemByName(string name) {
            return _items.FirstOrDefault(i => i.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
