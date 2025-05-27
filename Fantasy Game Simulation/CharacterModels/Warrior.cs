namespace Fantasy_Game_Simulation.CharacterModels {
    public class Warrior : Character {
        public Warrior(string name) {
            Name = name;
            Health = 150;
            AttackPower = 20;
            Defense = 10;
        }

        public override void DisplayStats() {
            Console.WriteLine($"{Name} the Warrior - HP: {Health}, AP: {AttackPower}, DEF: {Defense}");
        }
    }
}
