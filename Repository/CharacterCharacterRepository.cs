using Characters;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class CharacterCharacterRepository : RepositoryBase<CharacterCharacter>, ICharacterCharacterRepository
    {
        public CharacterCharacterRepository(RepositoryContext context) : base(context)
        {
        }
        public CharacterCharacter GetCharacterCharacter(int characterId, int friendId)
            => FindByCondition(ch => (ch.CharacterId == characterId) && (ch.FriendId == friendId)).FirstOrDefault();

        public void CreateCharacter(int characterId, CharacterCharacter characterCharacter)
        {
            characterCharacter.CharacterId = characterId;
            Create(characterCharacter);
        }
        public void DeleteCharacter(int characterId, CharacterCharacter characterCharacter)
        {
            characterCharacter.CharacterId = characterId;
            Delete(characterCharacter);
        }
    }
}
