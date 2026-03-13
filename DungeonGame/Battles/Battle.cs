using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonGame.Battles
{
    public class Battle
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }  
        public string CharacterName { get; set; }
        public int AverageCharacterPower { get; set; }
        public string MonsterName { get; set; }
        public int AverageMonsterPower { get; set; }
        public bool Result { get; set; }
        public int GoldEarned { get; set; }
        public DateTime BattleDate { get; set; }
        public bool IsActive { get; set; }

        public Battle()
        {
            IsActive = true;
        }
    }
}
