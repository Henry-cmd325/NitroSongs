using AutoMapper;
using NitroSongs.Common.Dtos;
using NitroSongs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NitroSongs.ApplicationLayer.Mappings
{
    public class SongProfile : Profile
    {
        public SongProfile()
        {
            CreateMap<Song, SongDto>()
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
                .ForMember(dest => dest.Rhythm, opt => opt.MapFrom(src => src.Rhythm.Name))
                .ForMember(dest => dest.Tone, opt => opt.MapFrom(src => src.Tone.Name))
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.Name));
        }
    }
}
