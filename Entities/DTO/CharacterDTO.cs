using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTO
{
    public class CharacterDTO
    {
        public int CharacterId { get; set; }
        public string Name { get; set; }
        public PlanetDTO Planet { get; set; }
        public ICollection<EpisodeDTO> Episodes { get; set; }
        public ICollection<FriendDTO> CharactersFriends { get; set; }
    }
}
