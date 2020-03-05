using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    public class Character
    {
        public Character()
        {
            CharactersFriends = new HashSet<CharacterCharacter>();
            CharactersEpisodes = new HashSet<CharacterEpisode>();
        }
        [Column("CharacterId")]
        public int CharacterId { get; set; }
        public string Name { get; set; }
        public virtual Planet Planet { get; set; }
        public int? PlanetId { get; set; }

        public virtual ICollection<CharacterEpisode> CharactersEpisodes { get; set; }
        public virtual ICollection<CharacterCharacter> CharactersFriends { get; set; }
        public virtual ICollection<CharacterCharacter> CharactersFriendsWithCharacter { get; set; }
    }
}
