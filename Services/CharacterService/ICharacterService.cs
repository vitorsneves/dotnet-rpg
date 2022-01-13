using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_rpg.Dtos.Character;
using dotnet_rpg.Models;

namespace dotnet_rpg.Services.CharacterService
{
    public interface ICharacterService
    {
        public Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters();
        public Task<ServiceResponse<GetCharacterDto?>> GetCharacterByid(int id);
        public Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter);
    }
}