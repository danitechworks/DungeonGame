using System;
using System.Collections.Generic;
using System.Text;
using DungeonGame.Entities;

namespace DungeonGame.Display
{
    public interface ICharacterDisplay
    {
        string DisplayCharacters(List<string> names);

        void DisplayCharacterStats(Character character);
    }
}
