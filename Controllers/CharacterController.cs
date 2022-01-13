using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_rpg.Dtos.Character;
using dotnet_rpg.Models;
using dotnet_rpg.Services.CharacterService;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_rpg.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet]
        [Route("select/{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> SelectCharacter(int id)
        {
            return Ok(await _characterService.GetCharacterByid(id));
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> GetAllCharacters()
        {
            return Ok(await _characterService.GetAllCharacters());
        }
        
        [HttpPost("add-character")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> AddCharacter(AddCharacterDto newCharacter)
        {
            return Ok(await _characterService.AddCharacter(newCharacter));
        }
    }
}