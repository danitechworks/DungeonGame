using DungeonGame.Database;
using DungeonGame.Display;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonGame.Entities
{
    public class PlayerHandler
    {
        private readonly IPlayerDisplay display;
        private readonly IDataBaseService dbService;

        public PlayerHandler(IPlayerDisplay display, IDataBaseService dbService)
        {
            this.display = display;
            this.dbService = dbService;
        }
        public Player CreateOrLoadPlayer()
        {
            var playerName = display.GetPlayerName();

            // Try to load from database
            var player = dbService.GetPlayer(playerName);

            // If not found, create a new player and save it
            if (player == null)
            {
                if (player == null)
                {
                    player = new Player(playerName);
                    dbService.SavePlayer(player); // Save and set Id
                }
            }
            
            AnsiConsole.MarkupLine($"[bold green]Welcome, [yellow]{player.PlayerName}[/]![/] Your adventure begins now.");
            return player;
        }
    }
}
