using DungeonGame.Entities;
using DungeonGame.GameLogic;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonGame.Display
{
    
    public class BattleDisplay : IDisplay, IBattleDisplay
    {
        private readonly GameSession gameSession;

        public BattleDisplay(GameSession gameSession)
        {
            this.gameSession = gameSession;
        }
        public void ShowBanner()
        {
            AnsiConsole.Write(
                new FigletText("Dungeon Game")
                    .Centered()
                    .Color(Color.Red));
        }

        public void DisplayStats()
        {
            AnsiConsole.Clear();
            ShowBanner();

            AnsiConsole.MarkupLine($"[bold green]Current Game Stats:[/]");

            var table = new Table();
            table.AddColumn("Name");            
            table.AddColumn("Power");
            table.AddColumn("Health");

            table.AddRow(gameSession.Character?.CharacterName, gameSession.Character.Power.ToString(), gameSession.Character.Health.ToString());
            table.AddRow(gameSession.Monster.MonsterName, gameSession.Monster.Power.ToString(), gameSession.Monster.Health.ToString());
            AnsiConsole.Write(table);
        }

        public void YouWon()
        {
            AnsiConsole.Clear();
            ShowBanner();
            AnsiConsole.Write(
                new FigletText("Victory!")
                    .Centered()
                    .Color(Color.Red));
            AnsiConsole.MarkupLine($"[bold yellow]You won {gameSession.Monster.GoldReward} pieces of Gold from {gameSession.Monster.MonsterName}[/]");

            AnsiConsole.MarkupLine($"{gameSession.Monster.MonsterName}'s average power was {gameSession.MonsterPower.Average()} and your average power was {gameSession.CharacterPower.Average()}");

            
        }

        public void YouLost()
        {
            AnsiConsole.Clear();
            ShowBanner();
            AnsiConsole.Write(
                new FigletText("Defeat!")
                    .Centered()
                    .Color(Color.Red));
            AnsiConsole.MarkupLine($"[bold red]You did not win any pieces of Gold from {gameSession.Monster.MonsterName}[/]");

            AnsiConsole.MarkupLine($"{gameSession.Monster.MonsterName}'s average power was {gameSession.MonsterPower.Average()} and your average power was {gameSession.CharacterPower.Average()}");

            
        }

        public void DisplayHistory()
        {
            AnsiConsole.MarkupLine("[bold green]Battle History:[/]");

            var table = new Table();
            table.AddColumn("Character");
            table.AddColumn(new TableColumn("Character\nAverage Power").Centered());
            table.AddColumn("Starting Health");
            table.AddColumn(new TableColumn("Enemy").Centered());
            table.AddColumn(new TableColumn("Enemy\nAverage Power").Centered());
            table.AddColumn(new TableColumn("Enemy\nStarting Health").Centered());
            table.AddColumn("Result");
            table.AddColumn("Gold Won");
            table.AddColumn("Battle Date");

            foreach (var battle in gameSession.BattleHistory)
            {
                var status = battle.Result ? "[green]Victory[/]" : "[red]Defeat[/]";
                var goldText = $"[yellow]{battle.GoldEarned}[/]";

                table.AddRow(
                    battle.CharacterName,
                    battle.AverageCharacterPower.ToString(),
                    battle.CharacterHealth.ToString(),
                    battle.MonsterName,
                    battle.AverageMonsterPower.ToString(),
                    battle.MonsterHealth.ToString(),
                    status,
                    goldText,
                    battle.BattleDate.ToString("MM/dd/yyyy HH:mm") 
                );
            }

            AnsiConsole.Write(table);
            AnsiConsole.MarkupLine($"[gray]press any key to continue[/]");
            Console.ReadKey();
        }
    }
}
