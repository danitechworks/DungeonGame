using DungeonGame.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using DungeonGame.Monster;
using DungeonGame.Battles;

namespace DungeonGame.GameLogic
{
    public class GameSession
    {
        public Player Player { get; set; }
        public Character Character { get; set; }
        public Monsters Monster { get; set; }
        public Battle CurrentBattle { get; set; }
        public List<Battle> BattleHistory { get; set; } = new List<Battle>();
        public List<int> CharacterPower { get; set; } = new List<int>();
        public List<int> MonsterPower { get; set; } = new List<int>();
        
    }
}
