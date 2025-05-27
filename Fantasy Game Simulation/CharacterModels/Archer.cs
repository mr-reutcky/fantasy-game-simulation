using Fantasy_Game_Simulation.SkillModels;

namespace Fantasy_Game_Simulation.CharacterModels {
    public class Archer : ICharacter {
        public string Name { get; set; }
        public int Health { get; set; }
        public int AttackPower { get; set; }
        public int Defense { get; set; }
        public List<ISkill> Skills { get; } = new List<ISkill>();

        public Archer(string name) {
            Name = name;
            Health = 100;
            AttackPower = 25;
            Defense = 7;
        }

        public void DisplayStats() {
            Console.WriteLine($"{Name} the Archer - HP: {Health}, AP: {AttackPower}, DEF: {Defense}");
        }
    }
}
