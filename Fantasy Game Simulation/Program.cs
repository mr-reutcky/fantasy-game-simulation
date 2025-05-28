using Fantasy_Game_Simulation.CharacterModels;
using Fantasy_Game_Simulation.ItemModels;
using Fantasy_Game_Simulation.SkillModels;

namespace Fantasy_Game_Simulation {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine("Initializing Game World...");
            Console.WriteLine();

            GameState game = GameState.GetInstance();
            game.Environment = "Dark Forest";
            game.DisplayWorldStatus();
            Console.WriteLine();

            Console.WriteLine("\nCreating Characters using Factory...");
            Console.WriteLine();

            ICharacter warrior = CharacterFactory.CreateCharacter("warrior", "Thorgar");
            ICharacter mage = CharacterFactory.CreateCharacter("mage", "Elandra");
            ICharacter archer = CharacterFactory.CreateCharacter("archer", "Lyra");

            game.Characters.AddRange(new[] { warrior, mage, archer });

            Console.WriteLine("Characters created:");
            Console.WriteLine();

            game.DisplayCharacterStats();
            Console.WriteLine();

            Console.WriteLine("\nAssigning Skills...");
            Console.WriteLine();

            ISkill fireball = new Fireball();
            ISkill frostRay = new FrostRay();
            LegacySkill legacySkill = new LegacySkill("Lightning Strike", 50);
            ISkill adaptedLegacySkill = new LegacySkillAdapter((LegacySkill)legacySkill);

            mage.Skills.Add(fireball);
            mage.Skills.Add(adaptedLegacySkill);
            archer.Skills.Add(frostRay);

            Console.WriteLine($"{mage.Name} learned: {fireball.Name}, {adaptedLegacySkill.Name}");
            Console.WriteLine($"{archer.Name} learned: {frostRay.Name}");
            Console.WriteLine();

            Console.WriteLine("\nInitializing Inventory Repository...");
            Console.WriteLine();

            IInventoryRepository inventory = new InventoryRepository();

            inventory.AddItem(new Item("Health Potion", "Consumable"));
            inventory.AddItem(new Item("Iron Sword", "Weapon"));
            inventory.AddItem(new Item("Mana Crystal", "Consumable"));

            Console.WriteLine("Inventory Items:");
            foreach (Item item in inventory.GetItems()) {
                Console.WriteLine($"- {item.Name} ({item.Type})");
            }
            Console.WriteLine();

            Console.WriteLine("\nRemoving Mana Crystal from inventory...");
            inventory.RemoveItem("Mana Crystal");
            Console.WriteLine();

            Console.WriteLine("Updated Inventory:");
            foreach (Item item in inventory.GetItems()) {
                Console.WriteLine($"- {item.Name} ({item.Type})");
            }
            Console.WriteLine();

            Console.WriteLine("Adding to the inventory...");
            inventory.AddItem(new Item("Elven Bow", "Weapon"));
            Console.WriteLine();

            Console.WriteLine("Updated Inventory:");
            foreach (Item item in inventory.GetItems()) {
                Console.WriteLine($"- {item.Name} ({item.Type})");
            }
            Console.WriteLine();

            Console.WriteLine("\nCombat Simulation:");
            Console.WriteLine();

            if (mage.IsAlive() && warrior.IsAlive()) {
                Console.WriteLine($"{mage.Name} uses {fireball.Name} on {warrior.Name}.");
                fireball.UseSkill();
                fireball.DealDamage(30, warrior);
                warrior.IsAlive();
                Console.WriteLine();
            }

            if (archer.IsAlive() && mage.IsAlive()) {
                Console.WriteLine($"\n{archer.Name} uses {frostRay.Name} on {mage.Name}.");
                frostRay.UseSkill();
                frostRay.DealDamage(40, mage);
                mage.IsAlive();
                Console.WriteLine();
            }

            if (mage.IsAlive() && archer.IsAlive()) {
                Console.WriteLine($"\n{mage.Name} uses {adaptedLegacySkill.Name} on {archer.Name}.");
                adaptedLegacySkill.UseSkill();
                adaptedLegacySkill.DealDamage(50, archer);
                archer.IsAlive();
                Console.WriteLine();
            }

            Console.WriteLine("\nSimulating Game Level Up...");
            Console.WriteLine();
            game.CurrentLevel++;
            game.Environment = "Ancient Ruins";
            Console.WriteLine($"Game progressed to Level {game.CurrentLevel} in {game.Environment}");
            Console.WriteLine();

            Console.WriteLine("\nFinal Character Status:");
            Console.WriteLine();

            foreach (ICharacter character in game.Characters) {
                character.IsAlive();
                character.DisplayStats();
                Console.WriteLine();
            }

            game.DisplayWorldStatus();
            Console.WriteLine();

            Console.WriteLine("\nGame Simulation Complete.");
        }
    }
}
