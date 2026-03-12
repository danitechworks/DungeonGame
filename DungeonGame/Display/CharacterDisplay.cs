using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonGame.Display
{
    public class CharacterDisplay : ICharacterDisplay, IDisplay
    {
        public string DisplayCharacters(List<string> names)
        {
            AnsiConsole.Clear();
            ShowBanner();
            var prompt = new SelectionPrompt<string>()
                .Title("Select a character:");

            foreach (var name in names)
                prompt.AddChoice(name);

            return AnsiConsole.Prompt(prompt);
        }

        public void ShowBanner()
        {
            AnsiConsole.Write(
                new FigletText("Dungeon Game")
                    .Centered()
                    .Color(Color.Red));
        }
    }
}
