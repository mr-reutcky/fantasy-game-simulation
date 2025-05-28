using Fantasy_Game_Simulation.CharacterModels;

namespace Fantasy_Game_Simulation.SkillModels {
    public class LegacySkillAdapter : ISkill {
        private readonly LegacySkill _legacySkill;

        public LegacySkillAdapter(LegacySkill legacySkill) {
            _legacySkill = legacySkill;
        }

        public string Name => _legacySkill.SkillName;

        public void UseSkill() {
            _legacySkill.ExecuteLegacySkill();
        }

        public void DealDamage(int damage, ICharacter character) {
            _legacySkill.ExecuteLegacySkill();
            character.TakeDamage(damage);
            Console.WriteLine($"{character.Name} is hit by legacy skill '{Name}' for {damage} damage!");
        }
    }
}
