using Characters;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly ILoggerManager _logger;
        public CharacterService(ILoggerManager logger)
        {
            _logger = logger;
        }

        public bool CharacterCharacterExists(CharacterCharacter characterCharacter)
        {
            if (characterCharacter == null)
            {
                _logger.LogError($"This character does not have specified friend.");
                return false;
            }
            return true;
        }

        public bool CharacterEpisodeExists(CharacterEpisode characterEpisode)
        {
            if (characterEpisode == null)
            {
                _logger.LogError($"This character does not play in specified episode.");
                return false;
            }
            return true;
        }

        public bool CharacterExists(Character character)
        {
            if (character == null)
            {
                _logger.LogError($"Character does not exist.");
                return false;
            }
            return true;
        }

        public bool EpisodeExists(Episode episode)
        {
            if (episode == null)
            {
                _logger.LogError($"Episode does not exist.");
                return false;
            }
            return true;
        }

        public bool PlanetExists(Planet planet)
        {
            if (planet == null)
            {
                _logger.LogError($"Planet does not exist.");
                return false;
            }
            return true;
        }
    }
}
