using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    public class Planet
    {
        [Column("PlanetId")]
        public int PlanetId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Character> Characters { get; set; }
    }
}
