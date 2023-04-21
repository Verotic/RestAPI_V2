using System.Collections.Generic;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using WebApplication1.Data;
using WebApplication2.Models;
namespace WebApplication2.Repositories
{

    public class PlayerRepository : IPlayerRepository
    {

        private MysqlConfiguration _connectionString;

        public PlayerRepository(MysqlConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        protected MySqlConnection dbConnect()
        {
            return new MySqlConnection( _connectionString.ConnectionString);
        }
        public async Task<Player> createPlayer(Player player)
        {
            var db = dbConnect();
            var sql = @"INSERT INTO player(name, age) VALUES (@name, @age); SELECT LAST_INSERT_ID()";
            player.Id = await db.QuerySingleAsync<int>(sql, new {player.Name, player.Age});
            return player;
        }

        public async Task<bool> deletePlayer(int id)
        {
            var db = dbConnect();
            var sql = @"DELETE FROM player WHERE id = @id";
            var result = await db.ExecuteAsync(sql,new { id });
            return result > 0;
        }


        public async Task<IEnumerable<Player>> GetPlayers()
        {
            var db = dbConnect();

            var sql = @"SELECT * FROM player";

            return await db.QueryAsync<Player>(sql, new { });
        }
        public async Task<Player> GetPlayer(int id)
        {
            var db = dbConnect();

            var sql = @"SELEC * FROM player WHERE id = @id";

            return await db.QueryFirstAsync<Player>(sql, new { id });
        }
        public async Task<bool> UpdatePlayer (Player player)
        {
            var db = dbConnect();
            var sql = @"UPDATE player SET name = @name, age = @age = WHERE id = @id";
            var result = await db.ExecuteAsync(sql, new { });
            return result > 0;
        }
    }
}
