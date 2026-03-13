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

            table.AddRow(gameSession.Character.CharacterName, gameSession.Character.Power.ToString(), gameSession.Character.Health.ToString());
            table.AddRow(gameSession.Monster.MonsterName, gameSession.Monster.Power.ToString(), gameSession.Monster.Health.ToString());
            AnsiConsole.Write(table);

        }
    }
}
