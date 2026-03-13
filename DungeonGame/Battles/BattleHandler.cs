using Autofac.Core;
using DungeonGame.Display;
using DungeonGame.Entities;
using DungeonGame.GameLogic;
using DungeonGame.Utilities;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;
using DungeonGame.Database;

namespace DungeonGame.Battles
{
    public class BattleHandler
    {
        private readonly GameSession gameSession;
        private readonly ICharacterDisplay characterDisplay;
        private readonly IMonsterDisplay monsterDisplay;
        private readonly IBattleDisplay battleDisplay;
        private readonly IDataBaseService dbService;

        public BattleHandler(GameSession gameSession, ICharacterDisplay characterDisplay, IMonsterDisplay monsterDisplay, IBattleDisplay battleDisplay, IDataBaseService dbService)
        {
            this.gameSession = gameSession;
            this.characterDisplay = characterDisplay;
            this.monsterDisplay = monsterDisplay;
            this.battleDisplay = battleDisplay;
            this.dbService = dbService;
        }
        public bool AttackMonster()
        {
            bool didWin;

            gameSession.CharacterPower.Add(gameSession.Character.Power);
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
                CreateBattleRecord(true, gameSession.Monster.GoldReward);
                battleDisplay.YouWon();
                battleDisplay.DisplayHistory();
                return true;
            }
            return false;
        }

        public bool AttackCharacter()
        {
            bool didWin;

            gameSession.MonsterPower.Add(gameSession.Monster.Power);
            gameSession.Monster.Power = RandomGenerator.SelectRandomPower();
            gameSession.Character.Health -= gameSession.Monster.Power;
           
            battleDisplay.DisplayStats();
            AnsiConsole.Markup($"{gameSession.Monster.MonsterName} did  {gameSession.Monster.Power} damage to you\n");
            
            AnsiConsole.MarkupLine($"[gray]press any key to continue[/]");
            Console.ReadKey();


            didWin = CheckIfWon();
            if (didWin)
            {
                CreateBattleRecord(false, 0);
                battleDisplay.YouLost();
                battleDisplay.DisplayHistory();
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

        public void CreateBattleRecord(bool result, int gold)
        {
            var battle = new Battle
            {
                CharacterName = gameSession.Character.CharacterName,
                AverageCharacterPower = (int)gameSession.CharacterPower.Average(),
                CharacterHealth = gameSession.CharacterStartingHealth,
                MonsterName = gameSession.Monster.MonsterName,
                AverageMonsterPower = (int)gameSession.MonsterPower.Average(),
                MonsterHealth = gameSession.MonsterStartingHealth,
                Result = result,
                GoldEarned = gold,
                BattleDate = DateTime.Now,
                IsActive = true
            };
            gameSession.BattleHistory.Add(battle);
            dbService.SaveBattle(battle, gameSession.Character.Id);
        }
    }
}
