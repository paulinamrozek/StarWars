using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configuration
{
    public class CharacterEpisodeConfiguration : IEntityTypeConfiguration<CharacterEpisode>
    {
        public void Configure(EntityTypeBuilder<CharacterEpisode> builder)
        {
            builder
                 .HasKey(ch => new { ch.CharacterId, ch.EpisodeId });
            builder
                .HasOne(ch => ch.Character)
                .WithMany(b => b.CharactersEpisodes)
                .HasForeignKey(f => f.CharacterId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(e => e.Episode)
                .WithMany(ch => ch.CharactersEpisodes)
                .HasForeignKey(chf => chf.EpisodeId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
