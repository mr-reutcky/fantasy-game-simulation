using Fantasy_Game_Simulation.CharacterModels;

namespace Fantasy_Game_Simulation.SkillModels {
    public class FrostRay : ISkill {
        public string Name => "Frost Ray";

        public void UseSkill() {
            Console.WriteLine($"Casting {Name}");
        }

        public void DealDamage(int damage, ICharacter character) {
            character.TakeDamage(damage);
            Console.WriteLine($"{character.Name} is hit by a {Name} for {damage} damage!");
        }
    }
}
