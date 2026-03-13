using DungeonGame.Display;
using DungeonGame.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonGame.Entities
{
    public class CharacterHandler
    {
        List<string> characterOptions = new List<string>
        {
            "Warrior",
            "Mage",
            "Rogue",
            "Paladin",
            "Ranger",
            "Necromancer",
            "Berserker",
            "Cleric",
            "Assassin",
            "Druid"
        };

        private readonly ICharacterDisplay characterDisplay;
        public CharacterHandler(ICharacterDisplay characterDisplay)
        {
            this.characterDisplay = characterDisplay;
        }
        public Character CreateCharacter()
        {
            var power = RandomGenerator.SelectRandomPower();
            var characterName = characterDisplay.DisplayCharacters(characterOptions);
            var health = RandomGenerator.SelectRandomHealth();  
            var character = new Character(characterName, power, health);

            characterDisplay.DisplayCharacterStats(character);
            return character;
        }
    }
}
