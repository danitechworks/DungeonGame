using System;
using System.Collections.Generic;
using System.Text;
using Spectre.Console;

namespace DungeonGame.Display
{
    public class PlayerDisplay : IDisplay
    {
        public string DisplayCharacters(List<string> names)
        {
            var characterName = new SelectionPrompt<string>()
                    .Title("Select a character:");

            for (int i = 0; i < names.Count; i++)
            {
                var item = names[i];
                characterName.AddChoice(item);
            }

            var choice = AnsiConsole.Prompt(characterName);
            return choice;
        }
    }
}
