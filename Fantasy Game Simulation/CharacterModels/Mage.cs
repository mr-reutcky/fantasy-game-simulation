namespace Fantasy_Game_Simulation.CharacterModels {
    public class Mage : Character{
        public Mage(string name) {
            Name = name;
            Health = 80;
            AttackPower = 30;
            Defense = 5;
        }

        public override void DisplayStats() {
            Console.WriteLine($"{Name} the Mage - HP: {Health}, AP: {AttackPower}, DEF: {Defense}");
        }
    }
}
