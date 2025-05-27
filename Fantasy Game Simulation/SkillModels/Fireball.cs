namespace Fantasy_Game_Simulation.SkillModels {
    public class Fireball : ISkill{
        public string Name => "Fireball";

        public void UseSkill() {
            Console.WriteLine("Casting Fireball!");
        }
    }
}
