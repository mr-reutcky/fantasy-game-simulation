using Fantasy_Game_Simulation.CharacterModels;

namespace Fantasy_Game_Simulation {
    public class GameState {
        private static GameState _instance;
        private static readonly object _lock = new object();

        public int CurrentLevel { get; set; } = 1;
        public List<ICharacter> Characters { get; } = new List<ICharacter>();
        public string Environment { get; set; } = "Forest";

        private GameState() { }

        public static GameState GetInstance() {
            if (_instance == null) {
                lock (_lock) {
                    if (_instance == null) {
                        _instance = new GameState();
                    }
                }
            }
            return _instance;
        }

        public void DisplayWorldStatus() {
            Console.WriteLine($"Current Level: {CurrentLevel}");
            Console.WriteLine($"Environment: {Environment}");
            Console.WriteLine("Characters in the game:");
            if (Characters.Count() == 0) {
                Console.WriteLine("No characters available.");
            } else {
                foreach (ICharacter character in Characters) {
                    character.DisplayStats();
                }
            }
        }

        public void DisplayCharacterStats() {
            if (Characters.Count() == 0) {
                Console.WriteLine("No characters available.");
            } else {
                Console.WriteLine("Character Stats:");
                foreach (ICharacter character in Characters) {
                    character.DisplayStats();
                }
            }
        }
    }
}
