namespace Fantasy_Game_Simulation.CharacterModels {
    public class Archer : Character {
        public Archer(string name) {
            Name = name;
            Health = 100;
            AttackPower = 25;
            Defense = 7;
        }

        public override void DisplayStats() {
            Console.WriteLine($"{Name} the Archer - HP: {Health}, AP: {AttackPower}, DEF: {Defense}");
        }
    }
}
