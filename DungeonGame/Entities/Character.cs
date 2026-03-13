using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonGame.Entities
{
    public class Character
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public string CharacterName { get; set; }   
        public int Level { get; set; }
        public int Health { get; set; }
        public int Power { get; set; }
        public int Gold { get; set; }
        public bool IsActive { get; set; }

        public Character(string name, int power)
        {
            CharacterName = name;
            Level = 1;
            Health = 70;
            Gold = 0;
            Power = power;
            IsActive = true;
        }
    }
}
