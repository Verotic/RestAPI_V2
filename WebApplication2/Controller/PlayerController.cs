using Microsoft.AspNetCore.Mvc;
using System;
using WebApplication2.Models;
using WebApplication2.Repositories;

namespace WebApplication2.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayerController : ControllerBase
    {
        private IPlayerRepository _playerRepository;
        public PlayerController(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }
        [HttpGet("all")]
        public async Task<IActionResult> getAll()
        {
            return Ok(await _playerRepository.GetPlayers());
        }
        [HttpDelete("{}")]
        [HttpGet("{id}")]
        public async Task<IActionResult> getPlayer(int id)
        {
            return Ok(await _playerRepository.GetPlayer(id));
        }
        [HttpPost]
        public async Task<IActionResult> createPlayer([FromBody] Player player)
        {
            if (player == null)
            {
                return BadRequest();
            }
            var created = await _playerRepository.createPlayer(player);

            return Created("Created", created);
        }

    }
}
