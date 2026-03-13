using DungeonGame.Display;
using DungeonGame.Entities;
using DungeonGame.GameLogic;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonGame.Battles
{
    public class BattleHandler
    {
        private readonly GameSession gameSession;
        private readonly ICharacterDisplay characterDisplay;
        private readonly IMonsterDisplay monsterDisplay;
        
        public BattleHandler(GameSession gameSession, ICharacterDisplay characterDisplay, IMonsterDisplay monsterDisplay)
        {
            this.gameSession = gameSession;
            this.characterDisplay = characterDisplay;
            this.monsterDisplay = monsterDisplay;
        }
        public bool AttackMonster()
        {
            bool didWin;
            gameSession.Monster.Health -= gameSession.Character.Power;
            characterDisplay.DisplayCharacterStats(gameSession.Character);
            didWin = CheckIfWon();
            if (didWin)
            {
                gameSession.Character.Gold += gameSession.Monster.GoldReward;
                return true;
            }
            return false;
        }

        public bool AttackCharacter()
        {
            bool didWin;
            gameSession.Character.Health -= gameSession.Monster.Power;
            monsterDisplay.DisplayMonsterStats(gameSession.Monster);
            didWin = CheckIfWon();
            if (didWin)
            {
                return true;
            }
            return false;
        }

        public bool CheckIfWon()
        {
            if (gameSession.Character.Health <= 0 || gameSession.Monster.Health <= 0)
                return true;
            else
                return false;
        }
    }
}
