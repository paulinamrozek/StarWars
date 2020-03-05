using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Configuration
{
    public class CharacterConfiguration : IEntityTypeConfiguration<Character>
    {
        public void Configure(EntityTypeBuilder<Character> builder)
        {
            builder.HasOne(ch => ch.Planet)
                .WithMany(p => p.Characters);
            builder.HasData
            (
                new Character
                {
                    CharacterId = 1,
                    Name = "Luke Skywalker"
                },
                new Character
                {
                    CharacterId = 2,
                    Name = "Darth Vader"
                },
                new Character
                {
                    CharacterId = 3,
                    Name = "Han Solo"
                },
                new Character
                {
                    CharacterId = 4,
                    Name = "Leia Organa"
                },
                new Character
                {
                    CharacterId = 5,
                    Name = "Wilhuff Tarkin"
                },
                new Character
                {
                    CharacterId = 6,
                    Name = "C-3PO"
                },
                new Character
                {
                    CharacterId = 7,
                    Name = "R2-D2"
                }
            );
        }
    }
}

