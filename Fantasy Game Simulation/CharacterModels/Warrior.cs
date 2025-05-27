using Fantasy_Game_Simulation.SkillModels;

namespace Fantasy_Game_Simulation.CharacterModels {
    public class Warrior : ICharacter {
        public string Name { get; set; }
        public int Health { get; set; }
        public int AttackPower { get; set; }
        public int Defense { get; set; }
        public List<ISkill> Skills { get; } = new List<ISkill>();


        public Warrior(string name) {
            Name = name;
            Health = 150;
            AttackPower = 20;
            Defense = 10;
        }

        public void DisplayStats() {
            Console.WriteLine($"{Name} the Warrior - HP: {Health}, AP: {AttackPower}, DEF: {Defense}");
        }
    }
}
