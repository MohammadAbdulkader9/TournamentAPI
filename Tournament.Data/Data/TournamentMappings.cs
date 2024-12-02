﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournament.Core.Dto;
using Tournament.Core.Entities;

namespace Tournament.Data.Data
{
    public class TournamentMappings : Profile
    {
        public TournamentMappings()
        {
            CreateMap<TournamentDetails, TournamentDto>();
            CreateMap<TournamentCreateDto, TournamentDetails>();
            CreateMap<TournamentUpdateDto, TournamentDetails>();

            CreateMap<Game, GameDto>();
            CreateMap<GameCreateDto, Game>();
            CreateMap<GameUpdateDto, Game>();
            //CreateMap<GameCreateDto, Game>()
            //.ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title));
        }

    }
}
