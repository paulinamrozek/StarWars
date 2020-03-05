using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configuration
{
    public class CharacterCharacterConfiguration : IEntityTypeConfiguration<CharacterCharacter>
    {
        public void Configure(EntityTypeBuilder<CharacterCharacter> builder)
        {
            builder
                 .HasKey(ch => new { ch.CharacterId, ch.FriendId });
            builder
                .HasOne(ch => ch.Character)
                .WithMany(b => b.CharactersFriends)
                .HasForeignKey(f => f.CharacterId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(ch => ch.Friend)
                .WithMany(f => f.CharactersFriendsWithCharacter)
                .HasForeignKey(bc => bc.FriendId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
