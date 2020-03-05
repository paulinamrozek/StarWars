using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Characters
{
    public interface ICharacterCharacterRepository
    {
        CharacterCharacter GetCharacterCharacter(int characterId, int friendId);
        void CreateCharacter(int characterId, CharacterCharacter characterCharacter);
        void DeleteCharacter(int characterId, CharacterCharacter characterCharacter);
    }
}
