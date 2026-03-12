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
        public void CreateCharacter()
        {
            var characterName = display.DisplayCharacters(characterOptions);
            var character = new Character(characterName);
            
            
        }
    }
}
