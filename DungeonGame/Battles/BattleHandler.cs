using DungeonGame.Display;
using DungeonGame.Entities;
using DungeonGame.GameLogic;
using DungeonGame.Utilities;
using Spectre.Console;
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
        private readonly IBattleDisplay battleDisplay;

        public BattleHandler(GameSession gameSession, ICharacterDisplay characterDisplay, IMonsterDisplay monsterDisplay, IBattleDisplay battleDisplay)
        {
            this.gameSession = gameSession;
            this.characterDisplay = characterDisplay;
            this.monsterDisplay = monsterDisplay;
            this.battleDisplay = battleDisplay;
        }
        public bool AttackMonster()
        {
            bool didWin;
            gameSession.Character.Power = RandomGenerator.SelectRandomPower();
            gameSession.Monster.Health -= gameSession.Character.Power;
                        
            battleDisplay.DisplayStats();
            AnsiConsole.Markup($"You did {gameSession.Character.Power} damage to {gameSession.Monster.MonsterName}\n");

            AnsiConsole.MarkupLine($"[gray]press any key to continue[/]");
            Console.ReadKey();

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
            gameSession.Monster.Power = RandomGenerator.SelectRandomPower();
            gameSession.Character.Health -= gameSession.Monster.Power;
           
            battleDisplay.DisplayStats();
            AnsiConsole.Markup($"{gameSession.Monster.MonsterName} did  {gameSession.Monster.Power} damage to you\n");

            AnsiConsole.MarkupLine($"[gray]press any key to continue[/]");
            Console.ReadKey();


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
