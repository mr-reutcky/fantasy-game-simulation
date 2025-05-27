namespace Fantasy_Game_Simulation.SkillModels {
    public class LegacySkill {
        public string SkillName { get; }
        public int Power { get; }

        public LegacySkill(string skillName, int power) {
            SkillName = skillName;
            Power = power;
        }

        public void ExecuteLegacySkill() {
            Console.WriteLine($"Executing legacy skill: {SkillName} with power {Power}");
        }
    }
}
