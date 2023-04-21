using Microsoft.AspNetCore.Mvc;
using System;
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
            return Ok (await _playerRepository.GetPlayers());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getPlayer((int id));
    }
}
