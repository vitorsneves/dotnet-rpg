using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotnet_rpg.Dtos.Character;
using dotnet_rpg.Models;

namespace dotnet_rpg.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private readonly IMapper _mapper;
        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;
        }

        private static List<Character> _characters = new List<Character>() 
        {
            new Character(),
            new Character() {Id = 1, Name = "Takk"},
            new Character() {Id = 2, Name = "Urask"}
        };
        
        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacterDto)
        {
            Character newCharacter =_mapper.Map<Character>(newCharacterDto);
            newCharacter.Id = _characters.Max(o => o.Id) + 1;
            _characters.Add(newCharacter);

            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            serviceResponse.Data = _characters.Select(o => _mapper.Map<GetCharacterDto>(o)).ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            serviceResponse.Data = _characters.Select(o => _mapper.Map<GetCharacterDto>(o)).ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterByid(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            serviceResponse.Data = _mapper.Map<GetCharacterDto>(_characters.FirstOrDefault(o => o.Id == id));
            
            return serviceResponse;
        }
    }
}