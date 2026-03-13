using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonGame.Display
{
    public interface IBattleDisplay
    {
        void DisplayStats();
        void YouWon();
        void YouLost();
        void DisplayHistory();
    }
}
