using System;
using System.Collections.Generic;
using System.Text;
using Spectre.Console;

namespace DungeonGame.Display
{
    public class PlayerDisplay : IDisplay
    {
        public void ShowBanner()
        {
            AnsiConsole.Write(
                new FigletText("Dungeon Game")
                    .Centered()
                    .Color(Color.Red));
        }

    }
}
