using Characters;
using Entities;
using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class CharacterRepository : RepositoryBase<Character>, ICharacterRepository
    {
        public CharacterRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        public void CreateCharacter(Character character) => Create(character);

        public void DeleteCharacter(Character character) => Delete(character);
        public void UpdateCharacter(Character character) => Update(character);

        public PagedList<Character> GetAllCharacters(CharacterParameters characterParameters)
        {
            var characters = FindAll()
             .OrderBy(c => c.CharacterId)
             .ToList();

            return PagedList<Character>
                .ToPagedList(characters, characterParameters.PageNumber, characterParameters.PageSize);
        }

        public Character GetCharacter(int id) =>
            FindByCondition(c => c.CharacterId.Equals(id)).FirstOrDefault();
    }
}
