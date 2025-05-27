using Fantasy_Game_Simulation.SkillModels;

namespace Fantasy_Game_Simulation.CharacterModels {
    public class Mage : ICharacter {
        public string Name { get; set; }
        public int Health { get; set; }
        public int AttackPower { get; set; }
        public int Defense { get; set; }
        public List<ISkill> Skills { get; } = new List<ISkill>();

        public Mage(string name) {
            Name = name;
            Health = 80;
            AttackPower = 30;
            Defense = 5;
        }

        public void DisplayStats() {
            Console.WriteLine($"{Name} the Mage - HP: {Health}, AP: {AttackPower}, DEF: {Defense}");
        }
    }
}
