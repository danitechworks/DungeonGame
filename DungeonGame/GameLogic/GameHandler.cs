using DungeonGame.Display;
using DungeonGame.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using DungeonGame.Utilities;
using DungeonGame.Monster;

namespace DungeonGame.GameLogic
{
    public class GameHandler
    {
        private readonly IDisplay display;
        private readonly PlayerHandler playerHandler;
        private readonly CharacterHandler characterHandler;
        private readonly MonsterHandler monsterHandler;

        public GameHandler(IDisplay display, PlayerHandler playerHandler, CharacterHandler characterHandler, MonsterHandler monsterHandler)
        {
            this.display = display;
            this.playerHandler = playerHandler;
            this.characterHandler = characterHandler;
            this.monsterHandler = monsterHandler;
        }

        public void RunApp()
        {
            Console.WriteLine("Welcome to the Dungeon Game!");
            playerHandler.CreatePlayer();
            characterHandler.CreateCharacter();
            monsterHandler.CreateMonster();

        }   
    }
}
