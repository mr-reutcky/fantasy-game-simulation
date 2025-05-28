using Fantasy_Game_Simulation.SkillModels;

namespace Fantasy_Game_Simulation.CharacterModels {
    public interface ICharacter {
        public string Name { get; set; }
        public int Health { get; set; }
        public int AttackPower { get; set; }
        public int Defense { get; set; }
        public List<ISkill> Skills { get; }

        public abstract void DisplayStats();
        public void TakeDamage(int damage) {
            int actualDamage = Math.Max(damage - Defense, 0);
            Health -= actualDamage;
            if (Health < 0) Health = 0;
            Console.WriteLine($"{Name} takes {actualDamage} damage! Remaining Health: {Health}");
        }

        public bool IsAlive() {
            if (Health < 0) {
                Health = 0;
                Console.WriteLine($"{Name} has fallen in battle!");
            }
            return Health > 0;
        }
    }
}
