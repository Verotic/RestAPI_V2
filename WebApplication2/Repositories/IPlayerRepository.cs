using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Repositories
{
    public interface IPlayerRepository
    {
        Task<IEnumerable<Player>> GetPlayers();

        Task<Player> GetPlayer(int id);
        Task<Player> createPlayer(Player player);
        Task<bool> UpdatePlayer(Player player);
        Task<bool> deletePlayer(int id);
    }
}
