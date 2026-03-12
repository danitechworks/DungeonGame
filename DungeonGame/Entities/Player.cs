using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonGame.Entities
{
    public class Player
    {
        public int Id { get; set; }
        public string PlayerName { get; set; }
        public bool IsActive { get; set; }

        public Player()
        {
            IsActive = true;
        }
    }
}
