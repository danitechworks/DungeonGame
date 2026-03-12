using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonGame.Entities
{
    public class PlayerHandler
    {
        public Player CreatePlayer()
        {
            Console.WriteLine("Enter your character's name:");
            string playerName = Console.ReadLine();
            var player = new Player(playerName);
            Console.WriteLine($"Welcome, {player.PlayerName}! Your adventure begins now.");
            return player;
        }
    }
}
