using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Characters;
using Entities;
using Entities.Models;

namespace Repository
{
    public class CharacterEpisodeRepository : RepositoryBase<CharacterEpisode>, ICharacterEpisodeRepository
    {
        public CharacterEpisodeRepository(RepositoryContext context) : base(context)
        {

        }
        public void CreateCharacterEpisode(int characterId, CharacterEpisode characterEpisode)
        {
            characterEpisode.CharacterId = characterId;
            Create(characterEpisode);
        }

        public void DeleteCharacterEpisode(int characterId, CharacterEpisode characterEpisode)
        {
            characterEpisode.CharacterId = characterId;
            Delete(characterEpisode);
        }

        public CharacterEpisode GetCharacterEpisode(int characterId, int episodeId)
         => FindByCondition(ch => (ch.CharacterId == characterId) && (ch.EpisodeId == episodeId)).FirstOrDefault();
    }
}
