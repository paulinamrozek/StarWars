using System;
using System.Collections.Generic;
using System.Text;

namespace Characters
{
    public interface IRepositoryManager
    {
        ICharacterRepository Character { get; }
        IPlanetRepository Planet { get; }
        IEpisodeRepository Episode { get; }
        ICharacterCharacterRepository CharacterCharacter { get; }
        ICharacterEpisodeRepository CharacterEpisode { get; }

        void Save();
    }
}
