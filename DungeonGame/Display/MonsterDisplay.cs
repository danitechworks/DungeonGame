using DungeonGame.Entities;
using DungeonGame.Monster;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonGame.Display
{
    public class MonsterDisplay : IMonsterDisplay, IDisplay
    {
        public void ShowBanner()
        {
            AnsiConsole.Write(
                new FigletText("Dungeon Game")
                    .Centered()
                    .Color(Color.Red));
        }

        public void DisplayMonsterStats(Monsters monster)
        {
            Console.Clear();
            ShowBanner();

            AnsiConsole.MarkupLine($"[bold green]The Monster Stats:[/]");

            var table = new Table();
            table.AddColumn("Monster Name");
            table.AddColumn("Power");
            table.AddColumn("Health");
            table.AddColumn("Gold Reward");
            table.AddRow(monster.MonsterName, monster.Power.ToString(), monster.Health.ToString(), monster.GoldReward.ToString());
            AnsiConsole.Write(table);

            AnsiConsole.MarkupLine($"[gray]press any key to continue[/]");
            Console.ReadKey();
        }
    }
}
