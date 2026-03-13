using System;
using System.Collections.Generic;
using System.Text;
using DungeonGame.Entities;
using DungeonGame.Battles;
using Microsoft.Data.SqlClient;

namespace DungeonGame.Database
{
    public interface IDataBaseService
    {
        Player GetPlayer(string name);
        void SavePlayer(Player player);

        Character GetCharacter(string characterName, int playerId);
        void SaveCharacter(Character character);

        void SaveBattle(Battle battle);
    }
}
