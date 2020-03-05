using Characters;
using Entities;
using Entities.Models;
using Moq;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace StarWars.Test
{
    public class RepositoryManagerTests
    {
        private RepositoryManager _repositoryManager;
        public RepositoryManagerTests()
        {
        }
        [Fact]
        public void Save_WritesCharacterToDatabase()
        {
            using (var dbContext = new InMemoryDbContextFactory().GetRepositoryContext())
            {
                var character = new Character()
                {
                    Name = "Test",
                    PlanetId = 1,
                };
                _repositoryManager = new RepositoryManager(dbContext);
                _repositoryManager.Character.CreateCharacter(character);
                _repositoryManager.Save();
            }
            using (var dbContext = new InMemoryDbContextFactory().GetRepositoryContext())
            {
                Assert.Equal(1, dbContext.Characters.Count());
                Assert.Equal("Test", dbContext.Characters.Single().Name);
            }
        }
    }
}
