using DungeonGame.Display;
using System;
using System.Collections.Generic;
using System.Text;
using Spectre.Console;

namespace DungeonGame.Entities
{
    public class PlayerHandler
    {
        private readonly IPlayerDisplay display;

        public PlayerHandler(IPlayerDisplay display)
        {
            this.display = display;
        }
        public Player CreatePlayer()
        {
            var playerName = display.GetPlayerName();            
            var player = new Player(playerName);
            AnsiConsole.MarkupLine($"[bold green]Welcome, [yellow]{player.PlayerName}[/]![/] Your adventure begins now.");
            return player;
        }
    }
}
