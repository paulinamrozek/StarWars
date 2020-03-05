using AutoMapper;
using Entities.DTO;
using Entities.Models;
using FluentAssertions;
using Xunit;

namespace StarWars.Test
{
    public class MappingsTests
    {
        private readonly IMapper _mapper;
        public MappingsTests()
        {
            var configurationProvider = new MapperConfiguration(cfg =>
          cfg.AddProfile(new MappingProfile()));
            _mapper = new Mapper(configurationProvider);
        }
        [Fact]
        public void WhenUpdateCharacter_ThenReturnCharacterEntity()
        {
            var characterForUpdateDTO = new CharacterForUpdateDTO()
            {
                Name = "test"
            };

            var mapped = _mapper.Map<Character>(characterForUpdateDTO);

            mapped.Name.Should().Be(characterForUpdateDTO.Name);
        }
    }
}

