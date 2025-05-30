﻿using Fantasy_Game_Simulation.CharacterModels;

namespace Fantasy_Game_Simulation.SkillModels {
    public class Fireball : ISkill{
        public string Name => "Fireball";

        public void UseSkill() {
            Console.WriteLine("Casting Fireball!");
        }

        public void DealDamage(int damage, ICharacter character) {
            character.TakeDamage(damage);
            Console.WriteLine($"{character.Name} is hit by a Fireball for {damage} damage!");
        }
    }
}
