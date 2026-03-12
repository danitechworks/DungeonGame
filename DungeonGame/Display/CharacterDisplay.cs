using DungeonGame.Entities;
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
            
            ShowBanner();
            var prompt = new SelectionPrompt<string>()
                .Title("Select a character:");

            foreach (var name in names)
                prompt.AddChoice(name);

            return AnsiConsole.Prompt(prompt);
        }

        public void ShowBanner()
        {
            AnsiConsole.Clear();
            AnsiConsole.Write(
                new FigletText("Dungeon Game")
                    .Centered()
                    .Color(Color.Red));
        }

        public void DisplayCharacterStats(Character character)
        {
            ShowBanner();

            AnsiConsole.MarkupLine($"[bold green]Your Character Stats:[/]");

            var table = new Table();
            table.AddColumn("Character");
            table.AddColumn("Level");
            table.AddColumn("Health");
            table.AddRow(character.CharacterName, character.Level.ToString(), character.Health.ToString());
            AnsiConsole.Write(table);

            AnsiConsole.MarkupLine($"[gray]press any key to continue[/]");
            Console.ReadKey();

        }

    }
}
