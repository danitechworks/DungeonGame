using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using DungeonGame.Entities;

namespace DungeonGame.Display
{
    public interface ICharacterDisplay
    {
        string DisplayCharacters(List<string> names);

        void DisplayCharacterStats(Character character);

        string CharacterMenu();
    }
}
