using Fantasy_Game_Simulation.CharacterModels;

namespace Fantasy_Game_Simulation.SkillModels {
    public interface ISkill {
        string Name { get; }
        void UseSkill();
        void DealDamage(int damage, ICharacter character);
    }
}
