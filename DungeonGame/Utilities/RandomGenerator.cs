using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonGame.Utilities
{
    public class RandomGenerator
    {
        public static int SelectRandomMonster()
        {
            Random random = new Random();
            int randomIndex = random.Next(0, 20);  
            return randomIndex;
        }

        public static int SelectRandomPower()
        {
            Random random = new Random();
            int randomPower = random.Next(1, 11);  
            return randomPower;
        }

        public static int SelectRandomHealth()
        {
            Random random = new Random();
            int randomHealth = random.Next(20, 40);  
            return randomHealth;
        }

        public static int SelectRandomGoldReward()
        {
            Random random = new Random();
            int randomGoldReward = random.Next(10, 51);  
            return randomGoldReward;
        }
    }
}
