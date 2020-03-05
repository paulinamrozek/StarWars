using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class CharacterEpisode
    {
        public virtual Character Character { get; set; }
        public int CharacterId { get; set; }
        public virtual Episode Episode { get; set; }
        public int EpisodeId { get; set; }
    }
}
