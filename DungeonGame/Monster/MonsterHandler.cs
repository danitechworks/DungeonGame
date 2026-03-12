using DungeonGame.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonGame.Monster
{
    public class MonsterHandler
    {
        List<string> monsterNames = new List<string>
        {
            "Goblin",
            "Cave Rat",
            "Skeleton Warrior",
            "Zombie Brute",
            "Shadow Wolf",
            "Cave Spider",
            "Orc Raider",
            "Dark Cultist",
            "Stone Golem",
            "Fire Imp",
            "Swamp Troll",
            "Frost Wraith",
            "Blood Bat",
            "Venom Serpent",
            "Crypt Ghoul",
            "Iron Sentinel",
            "Bone Dragonling",
            "Abyss Hound",
            "Plague Harvester",
            "Void Stalker"
        };

        public void CreateMonster()
        {
            var nameIndex = RandomGenerator.SelectRandomMonster();
            var name = monsterNames[nameIndex];
            var power = RandomGenerator.SelectRandomPower();
            var health = RandomGenerator.SelectRandomHealth();
            var goldReward = RandomGenerator.SelectRandomGoldReward();
            var monster = new Monsters(name, power, health, goldReward);
        }
    }
}
