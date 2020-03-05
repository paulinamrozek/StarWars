using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Characters
{
    public interface ICharacterService
    {
        bool CharacterExists(Character character);
        bool PlanetExists(Planet planet);
        bool EpisodeExists(Episode episode);
        bool CharacterCharacterExists(CharacterCharacter characterCharacter);
        bool CharacterEpisodeExists(CharacterEpisode characterEpisode);
    }
}
