namespace Fantasy_Game_Simulation.ItemModels {
    public class Item {
        public string Name { get; set; }
        public string Type { get; set; }

        public Item(string name, string type) {
            Name = name;
            Type = type;
        }
    }
}
