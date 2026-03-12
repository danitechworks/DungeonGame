using DungeonGame.Display;
using DungeonGame.Entities;
using DungeonGame.Monster;
using DungeonGame.Utilities;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace DungeonGame.GameLogic
{
    public class GameHandler
    {
        private readonly PlayerHandler playerHandler;
        private readonly CharacterHandler characterHandler;
        private readonly MonsterHandler monsterHandler;

        public GameHandler(PlayerHandler playerHandler, CharacterHandler characterHandler, MonsterHandler monsterHandler)
        {
            this.playerHandler = playerHandler;
            this.characterHandler = characterHandler;
            this.monsterHandler = monsterHandler;
        }

        public void RunApp()
        {
            Console.WriteLine("Welcome to the Dungeon Game!");
            var player = playerHandler.CreatePlayer();
            var character = characterHandler.CreateCharacter();
            var monster = monsterHandler.CreateMonster();

            
        }   
    }
}
