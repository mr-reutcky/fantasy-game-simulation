using Fantasy_Game_Simulation.CharacterModels;
using Fantasy_Game_Simulation.ItemModels;
using Fantasy_Game_Simulation.SkillModels;

namespace Fantasy_Game_Simulation {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine("=== Welcome to the Fantasy Game Simulation ===\n");

            // Singleton: Game World
            Console.WriteLine("Initializing Game World...");
            GameState world = GameState.GetInstance();
            world.Environment = "Mystic Ruins";
            world.CurrentLevel = 1;
            Console.WriteLine("Game World Initialized.\n");

            // Factory: Character Creation
            Console.WriteLine("Creating characters using the Factory Pattern...");
            ICharacter mage = CharacterFactory.CreateCharacter("mage", "Elandra");
            ICharacter warrior = CharacterFactory.CreateCharacter("warrior", "Gorim");
            world.Characters.Add(mage);
            world.Characters.Add(warrior);
            Console.WriteLine("Characters created and added to the world.\n");

            // Inventory: Repository
            Console.WriteLine("Initializing inventory and adding items...");
            IInventoryRepository inventory = new InventoryRepository();
            inventory.AddItem(new Item("Sword of Truth", "Weapon"));
            inventory.AddItem(new Item("Healing Potion", "Potion"));
            inventory.AddItem(new Item("Orb of Vision", "Artifact"));
            Console.WriteLine("Items added to inventory.\n");

            // Adapter: Adapting legacy skill
            Console.WriteLine("Adapting legacy skill to new skill system...");
            LegacySkill oldSkill = new LegacySkill("Ancient Blast", 50);
            ISkill adaptedSkill = new LegacySkillAdapter(oldSkill);
            Console.WriteLine("Legacy skill adapted.\n");

            // Assign Skills
            Console.WriteLine("Assigning skills to characters...");
            ISkill fireball = new Fireball();
            mage.Skills.Add(fireball);
            warrior.Skills.Add(adaptedSkill);
            Console.WriteLine("Skills assigned.\n");

            // Display Game World State
            Console.WriteLine("Displaying current game world state:");
            world.DisplayWorldStatus();

            // Display Inventory
            Console.WriteLine("\nDisplaying inventory items:");
            foreach (Item item in inventory.GetItems()) {
                Console.WriteLine($"- {item.Type}: {item.Name}");
            }

            // Characters use skills
            Console.WriteLine("\nCharacters demonstrating their skills:");
            foreach (ICharacter character in world.Characters) {
                Console.WriteLine($"\n{character.Name}'s Skills:");
                foreach (ISkill skill in character.Skills) {
                    skill.UseSkill();
                }
            }

            Console.WriteLine("\n=== Simulation Complete ===");
        }
    }
}
