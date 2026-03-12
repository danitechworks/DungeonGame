using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonGame.Monster
{
    public class Monsters
    {
        public int Id { get; set; }
        public string MonsterName { get; set; }
        public int Power { get; set; }
        public int Health { get; set; }
        public int GoldReward { get; set; }
        public bool IsActive { get; set; }
    }
}
