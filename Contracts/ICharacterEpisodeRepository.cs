using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Characters
{
    public interface ICharacterEpisodeRepository
    {
        CharacterEpisode GetCharacterEpisode(int characterId, int friendId);
        void CreateCharacterEpisode(int characterId, CharacterEpisode characterEpisode);
        void DeleteCharacterEpisode(int characterId, CharacterEpisode characterEpisode);
    }
}
