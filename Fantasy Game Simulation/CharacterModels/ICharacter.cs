using Fantasy_Game_Simulation.SkillModels;

namespace Fantasy_Game_Simulation.CharacterModels {
    public interface ICharacter {
        public string Name { get; set; }
        public int Health { get; protected set; }
        public int AttackPower { get; protected set; }
        public int Defense { get; protected set; }
        public List<ISkill> Skills { get; }

        public abstract void DisplayStats();
    }
}
