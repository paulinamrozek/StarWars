using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    public class CharacterCharacter
    {
        public virtual Character Character { get; set; }
        public int CharacterId { get; set; }

        [ForeignKey("FriendId")]
        public virtual Character Friend { get; set; }
        public int FriendId { get; set; }
    }
}
