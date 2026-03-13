using Autofac.Core;
using DungeonGame.Database;
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

        private readonly IDataBaseService dbService;

        private readonly ICharacterDisplay characterDisplay;
        public CharacterHandler(ICharacterDisplay characterDisplay, IDataBaseService dbService)
        {
            this.characterDisplay = characterDisplay;
            this.dbService = dbService;
        }
        public Character CreateOrLoadCharacter(int playerId)
        {
            var name = characterDisplay.DisplayCharacters(characterOptions);

            // Try to get character from database
            var character = dbService.GetCharacter(name, playerId);

            if (character == null)
            {
                // Generate random stats
                int health = RandomGenerator.SelectRandomHealth();
                int power = RandomGenerator.SelectRandomPower();

                // Use the constructor with parameters
                character = new Character(name, power, health)
                {
                    PlayerId = playerId
                };
                dbService.SaveCharacter(character);
            }

            return character;
        }
    }
}
