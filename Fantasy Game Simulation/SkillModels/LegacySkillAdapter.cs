namespace Fantasy_Game_Simulation.SkillModels {
    internal class LegacySkillAdapter : ISkill {
        private readonly LegacySkill _legacySkill;

        public LegacySkillAdapter(LegacySkill legacySkill) {
            _legacySkill = legacySkill;
        }

        public string Name => _legacySkill.SkillName;

        public void UseSkill() {
            _legacySkill.ExecuteLegacySkill();
        }
    }
}
