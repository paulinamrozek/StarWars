using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    public class Episode
    {
        [Column("EpisodeId")]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<CharacterEpisode> CharactersEpisodes { get; set; }
    }
}
