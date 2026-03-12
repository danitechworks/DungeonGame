using System;
using System.Collections.Generic;
using System.Text;
using Spectre.Console;

namespace DungeonGame.Display
{
    public class PlayerDisplay : IDisplay, IPlayerDisplay
    {
        public void ShowBanner()
        {
            AnsiConsole.Write(
                new FigletText("Dungeon Game")
                    .Centered()
                    .Color(Color.Red));
        }

        public string GetPlayerName()
        {
            AnsiConsole.Clear();
            ShowBanner();
            var playerName = AnsiConsole.Ask<string>("Enter your [green]player name[/]:");

            AnsiConsole.MarkupLine($"[bold green]Welcome to the game {playerName}[/]");
            AnsiConsole.MarkupLine($"[gray]press any key to continue[/]");
            Console.ReadKey();
            return playerName;
        }
    }
}
