using Characters;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;
        private ICharacterRepository _characterRepository;
        private IPlanetRepository _planetRepository;
        private IEpisodeRepository _episodeRepository;
        private ICharacterCharacterRepository _characterCharacterRepository;
        private ICharacterEpisodeRepository _characterEpisodeRepository;
        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public ICharacterRepository Character
        {
            get
            {
                if (_characterRepository == null)
                    _characterRepository = new CharacterRepository(_repositoryContext);
                return _characterRepository;
            }
        }
        public IPlanetRepository Planet
        {
            get
            {
                if (_planetRepository == null)
                    _planetRepository = new PlanetRepository(_repositoryContext);
                return _planetRepository;
            }
        }
        public IEpisodeRepository Episode
        {
            get
            {
                if (_episodeRepository == null)
                    _episodeRepository = new EpisodeRepository(_repositoryContext);
                return _episodeRepository;
            }
        }

        public ICharacterCharacterRepository CharacterCharacter
        {
            get
            {
                if (_characterCharacterRepository == null)
                    _characterCharacterRepository = new CharacterCharacterRepository(_repositoryContext);
                return _characterCharacterRepository;
            }
        }
        public ICharacterEpisodeRepository CharacterEpisode
        {
            get
            {
                if (_characterEpisodeRepository == null)
                    _characterEpisodeRepository = new CharacterEpisodeRepository(_repositoryContext);
                return _characterEpisodeRepository;
            }
        }
        public void Save() => _repositoryContext.SaveChanges();
    }
}
