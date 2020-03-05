using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Characters
{
    public interface ICharacterRepository
    {
        PagedList<Character> GetAllCharacters(CharacterParameters characterParameters);
        Character GetCharacter(int id);
        void CreateCharacter(Character character);
        void DeleteCharacter(Character character);
        void UpdateCharacter(Character character);
    }
}
