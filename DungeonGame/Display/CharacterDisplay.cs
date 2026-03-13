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
            table.AddColumn("Power");
            table.AddColumn("Health");
            table.AddRow(character.CharacterName, character.Level.ToString(), character.Power.ToString(), character.Health.ToString());
            AnsiConsole.Write(table);

            AnsiConsole.MarkupLine($"[gray]press any key to continue[/]");
            Console.ReadKey();
        }

        public string CharacterMenu()
        {
            AnsiConsole.Clear ();
            ShowBanner();

            var menu = new SelectionPrompt<string>().Title("What would you like to do?");
            menu.AddChoice("Attack");
            menu.AddChoice("See Instructions");
            menu.AddChoice("See Battle History");
            menu.AddChoice("Exit");

            var choice = AnsiConsole.Prompt(menu);
            return choice;
        }

    }
}
