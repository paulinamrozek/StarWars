using AutoMapper;
using Entities.DTO;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Character, CharacterDTO>()
                .ForMember(chd => chd.Episodes, opt => opt.MapFrom(ch => ch.CharactersEpisodes));
            CreateMap<Episode, EpisodeDTO>();
            CreateMap<Planet, PlanetDTO>();
            CreateMap<CharacterCharacter, FriendDTO>()
                .ForMember(f => f.Name, opt => opt.MapFrom(ch => ch.Friend.Name));
            CreateMap<CharacterEpisode, EpisodeDTO>()
                .ForMember(e => e.Name, opt => opt.MapFrom(che => che.Episode.Name));

            CreateMap<CharacterForCreationDTO, Character>();

            CreateMap<CharacterForUpdateDTO, Character>();
            CreateMap<CharacterForUpdateFriendsDTO, CharacterCharacter>();
            CreateMap<CharacterForUpdateEpisodesDTO, CharacterEpisode>();
            CreateMap<CharacterForUpdatePlanetDTO, Character>();
        }
    }
}
