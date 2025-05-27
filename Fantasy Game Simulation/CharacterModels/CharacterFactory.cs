namespace Fantasy_Game_Simulation.CharacterModels {
    public class CharacterFactory {
        public static ICharacter CreateCharacter(string type, string name) {
            ICharacter character;

            switch (type.ToLower()) {
                case "warrior":
                character = new Warrior(name);
                break;
                case "mage":
                character = new Mage(name);
                break;
                case "archer":
                character = new Archer(name);
                break;
                default:
                throw new ArgumentException("Invalid character type");
            }

            return character;
        }
    }
}
