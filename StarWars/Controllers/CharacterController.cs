using AutoMapper;
using Characters;
using Entities.DTO;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.RequestFeatures;

namespace StarWars
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        private IRepositoryManager _repositoryManager;
        private ILoggerManager _logger;
        private IMapper _mapper;
        private ICharacterService _service;
        public CharacterController(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper, ICharacterService service)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public IActionResult GetCharacters([FromQuery] CharacterParameters characterParameters)
        {
            var characters = _repositoryManager.Character.GetAllCharacters(characterParameters);
            var charactersDTO = _mapper.Map<IEnumerable<CharacterDTO>>(characters);

            return Ok(charactersDTO);
        }
        [HttpGet("{id}", Name = "CharacterById")]
        public IActionResult GetCharacter(int id)
        {
            var characterEntity = _repositoryManager.Character.GetCharacter(id);
            if (!_service.CharacterExists(characterEntity))
                return NotFound();

            var characterDTO = _mapper.Map<CharacterDTO>(characterEntity);

            return Ok(characterDTO);
        }
        [HttpPost]
        public IActionResult Post([FromBody] CharacterForCreationDTO character)
        {
            if (character == null)
            {
                _logger.LogError("CharacterForCreationDto object sent from client is null.");
                return BadRequest("CharacterForCreationDto object is null");
            }

            var characterEntity = _mapper.Map<Character>(character);
            _repositoryManager.Character.CreateCharacter(characterEntity);
            _repositoryManager.Save();

            var characterToReturn = _mapper.Map<CharacterDTO>(characterEntity);

            return CreatedAtRoute("CharacterById", new { id = characterToReturn.CharacterId }, characterToReturn);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var characterEntity = _repositoryManager.Character.GetCharacter(id);
            if (!_service.CharacterExists(characterEntity))
                return NotFound();

            _repositoryManager.Character.DeleteCharacter(characterEntity);
            _repositoryManager.Save();

            return NoContent();
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, CharacterForUpdateDTO character)
        {
            var characterEntity = _repositoryManager.Character.GetCharacter(id);

            if (!_service.CharacterExists(characterEntity))
                return NotFound();

            _mapper.Map(character, characterEntity);
            _repositoryManager.Save();

            return NoContent();
        }
        [HttpPut("UpdatePlanet/{id}")]
        public IActionResult UpdatePlanet(int id, CharacterForUpdatePlanetDTO character)
        {
            var characterEntity = _repositoryManager.Character.GetCharacter(id);

            if (!_service.CharacterExists(characterEntity))
                return NotFound();

            if (character.PlanetId.HasValue)
            {
                var planetEntity = _repositoryManager.Planet.GetPlanet(character.PlanetId.Value);
                if (!_service.PlanetExists(planetEntity))
                    return NotFound();
            }
            _mapper.Map(character, characterEntity);
            _repositoryManager.Save();

            return NoContent();
        }
        [HttpPut("AddFriend/{id}")]
        public IActionResult UpdateFriends(int id, CharacterForUpdateFriendsDTO character)
        {
            var characterEntity = _repositoryManager.Character.GetCharacter(id);
            var friendEntity = _repositoryManager.Character.GetCharacter(character.FriendId);
            if (!_service.CharacterExists(characterEntity) || !_service.CharacterExists(friendEntity))
                return NotFound();

            var characterCharacter = _mapper.Map<CharacterCharacter>(character);
            _repositoryManager.CharacterCharacter.CreateCharacter(id, characterCharacter);

            _repositoryManager.Save();
            return NoContent();
        }
        [HttpPut("DeleteFriend/{id}")]
        public IActionResult DeleteFriends(int id, CharacterForUpdateFriendsDTO character)
        {
            var characterEntity = _repositoryManager.Character.GetCharacter(id);
            var friendEntity = _repositoryManager.Character.GetCharacter(character.FriendId);
            var characterCharacterEntity = _repositoryManager.CharacterCharacter.GetCharacterCharacter(id, character.FriendId);

            if (!_service.CharacterExists(characterEntity) || !_service.CharacterCharacterExists(characterCharacterEntity) || !_service.CharacterExists(friendEntity))
                return NotFound();

            _repositoryManager.CharacterCharacter.DeleteCharacter(id, characterCharacterEntity);

            _repositoryManager.Save();
            return NoContent();
        }
        [HttpPut("AddEpisode/{id}")]
        public IActionResult UpdateEpisodes(int id, CharacterForUpdateEpisodesDTO character)
        {
            var characterEntity = _repositoryManager.Character.GetCharacter(id);
            var episodeEntity = _repositoryManager.Episode.GetEpisode(character.EpisodeId);
            if (!_service.CharacterExists(characterEntity) || !_service.EpisodeExists(episodeEntity))
                return NotFound();

            var characterEpisode = _mapper.Map<CharacterEpisode>(character);
            _repositoryManager.CharacterEpisode.CreateCharacterEpisode(id, characterEpisode);

            _repositoryManager.Save();
            return NoContent();
        }
        [HttpPut("DeleteEpisode/{id}")]
        public IActionResult DeleteEpisodes(int id, CharacterForUpdateEpisodesDTO character)
        {
            var characterEntity = _repositoryManager.Character.GetCharacter(id);
            var episodeEntity = _repositoryManager.Episode.GetEpisode(character.EpisodeId);
            var characterEpisodeEntity = _repositoryManager.CharacterEpisode.GetCharacterEpisode(id, character.EpisodeId);
            if (!_service.CharacterExists(characterEntity) || !_service.EpisodeExists(episodeEntity) || !_service.CharacterEpisodeExists(characterEpisodeEntity))
                return NotFound();

            _repositoryManager.CharacterEpisode.DeleteCharacterEpisode(id, characterEpisodeEntity);

            _repositoryManager.Save();
            return NoContent();
        }
    }

}
