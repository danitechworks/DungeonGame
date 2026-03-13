using System;
using System.Collections.Generic;
using System.Text;
using DungeonGame.Entities;
using DungeonGame.Battles;
using Microsoft.Data.SqlClient;

namespace DungeonGame.Database
{
    public class DatabaseService : IDataBaseService
    {
        private readonly string _connectionString = "Server=localhost;Database=DungeonGame;Integrated Security=True;TrustServerCertificate=True;";
        public Player GetPlayer(string name)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            var cmd = new SqlCommand("SELECT Id, PlayerName, IsActive FROM Players WHERE PlayerName=@name", conn);
            cmd.Parameters.AddWithValue("@name", name);
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Player(reader.GetString(1))
                {
                    Id = reader.GetInt32(0),
                    IsActive = reader.GetBoolean(2)
                };
            }
            return null;
        }

        public void SavePlayer(Player player)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            var cmd = new SqlCommand(
                "INSERT INTO Players (PlayerName, IsActive) OUTPUT INSERTED.Id VALUES (@name, @active)", conn);
            cmd.Parameters.AddWithValue("@name", player.PlayerName);
            cmd.Parameters.AddWithValue("@active", player.IsActive);
            player.Id = (int)cmd.ExecuteScalar();
        }

        public Character GetCharacter(string characterName, int playerId)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();

            var cmd = new SqlCommand(@"
        SELECT Id, CharacterName, Level, Health, Gold, IsActive
        FROM Characters
        WHERE PlayerId=@pid AND CharacterName=@name", conn);

            cmd.Parameters.AddWithValue("@pid", playerId);
            cmd.Parameters.AddWithValue("@name", characterName);

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new Character
                {
                    Id = reader.GetInt32(0),
                    CharacterName = reader.GetString(1),
                    Level = reader.GetInt32(2),
                    Health = reader.GetInt32(3),
                    Gold = reader.GetInt32(4),
                    IsActive = reader.GetBoolean(5),
                    PlayerId = playerId
                };
            }

            return null;
        }

        public void SaveCharacter(Character character)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            var cmd = new SqlCommand(
                "INSERT INTO Characters (PlayerId, CharacterName, Level, Health, Gold, IsActive) OUTPUT INSERTED.Id " +
                "VALUES (@pid, @name, @level, @health, @gold, @active)", conn);
            cmd.Parameters.AddWithValue("@pid", character.PlayerId);
            cmd.Parameters.AddWithValue("@name", character.CharacterName);
            cmd.Parameters.AddWithValue("@level", character.Level);
            cmd.Parameters.AddWithValue("@health", character.Health);
            cmd.Parameters.AddWithValue("@gold", character.Gold);
            cmd.Parameters.AddWithValue("@active", character.IsActive);
            character.Id = (int)cmd.ExecuteScalar();
        }

        public void SaveBattle(Battle battle, int characterId)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();

            var cmd = new SqlCommand(@"
        INSERT INTO Battles
        (CharacterId, CharacterName, CharacterHealth, AverageCharacterPower,
         MonsterName, MonsterHealth, AverageMonsterPower, Result, GoldEarned, BattleDate, IsActive)
        VALUES
        (@CharacterId, @CharacterName, @CharacterHealth, @AverageCharacterPower,
         @MonsterName, @MonsterHealth, @AverageMonsterPower, @Result, @GoldEarned, @BattleDate, @IsActive)", conn);

            cmd.Parameters.AddWithValue("@CharacterId", characterId);
            cmd.Parameters.AddWithValue("@CharacterName", battle.CharacterName);
            cmd.Parameters.AddWithValue("@CharacterHealth", battle.CharacterHealth);
            cmd.Parameters.AddWithValue("@AverageCharacterPower", battle.AverageCharacterPower);
            cmd.Parameters.AddWithValue("@MonsterName", battle.MonsterName);
            cmd.Parameters.AddWithValue("@MonsterHealth", battle.MonsterHealth);
            cmd.Parameters.AddWithValue("@AverageMonsterPower", battle.AverageMonsterPower);
            cmd.Parameters.AddWithValue("@Result", battle.Result);
            cmd.Parameters.AddWithValue("@GoldEarned", battle.GoldEarned);
            cmd.Parameters.AddWithValue("@BattleDate", battle.BattleDate);
            cmd.Parameters.AddWithValue("@IsActive", battle.IsActive);

            cmd.ExecuteNonQuery();
        }

    }
}
