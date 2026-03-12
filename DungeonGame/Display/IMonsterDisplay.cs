using DungeonGame.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using DungeonGame.Monster;

namespace DungeonGame.Display
{
    public interface IMonsterDisplay
    {
        void DisplayMonsterStats(Monsters monster);
    }
}
