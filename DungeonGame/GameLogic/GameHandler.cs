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
        private readonly ICharacterDisplay characterDisplay;

        public GameHandler(PlayerHandler playerHandler, CharacterHandler characterHandler, MonsterHandler monsterHandler, ICharacterDisplay characterDisplay)
        {
            this.playerHandler = playerHandler;
            this.characterHandler = characterHandler;
            this.monsterHandler = monsterHandler;
            this.characterDisplay = characterDisplay;
        }

        public void RunApp()
        {
            var player = playerHandler.CreatePlayer();
            var character = characterHandler.CreateCharacter();
            var monster = monsterHandler.CreateMonster();            

            bool willQuit = false;
            while(willQuit == false)
            {
                var choice = characterDisplay.CharacterMenu();
                switch (choice)
                {
                    case "fight":
                        break;

                    case "See Instructions":
                        break;

                    case "Exit":
                        break;
                }
            }
            
        } 
        

    }
}
