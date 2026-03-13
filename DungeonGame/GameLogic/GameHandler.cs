using DungeonGame.Battles;
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
        private readonly BattleHandler battleHandler;
        private readonly GameSession gameSession;
        private readonly IBattleDisplay battleDisplay;

        public GameHandler(PlayerHandler playerHandler, CharacterHandler characterHandler, MonsterHandler monsterHandler, ICharacterDisplay characterDisplay, BattleHandler battleHandler, GameSession gameSession, IBattleDisplay battleDisplay)
        {
            this.playerHandler = playerHandler;
            this.characterHandler = characterHandler;
            this.monsterHandler = monsterHandler;
            this.characterDisplay = characterDisplay;
            this.battleHandler = battleHandler;
            this.gameSession = gameSession;
            this.battleDisplay = battleDisplay;
        }

        public void RunApp()
        {
            
            gameSession.Player = playerHandler.CreatePlayer(); 
            gameSession.Character = characterHandler.CreateCharacter();
            gameSession.Monster = monsterHandler.CreateMonster();            

            bool willQuit = false;
            while(willQuit == false)
            {
                var choice = characterDisplay.CharacterMenu();
                switch (choice)
                {
                    case "Attack":
                        
                        var didWin = battleHandler.AttackMonster();
                        
                        if (didWin)
                        {
                            battleDisplay.YouWon();
                            break;
                        }

                        didWin = battleHandler.AttackCharacter();
                        if (didWin)
                        {
                            battleDisplay.YouLost();
                            break;
                        }
                        break;

                    case "See Instructions":
                        break;

                    case "Exit":
                        willQuit = true;
                        break;
                }
            }
            
        } 
        

    }
}
