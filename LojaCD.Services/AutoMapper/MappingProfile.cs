using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaCD.Services.AutoMapper
{
    using AutoMapper;
    using global::AutoMapper;
    using LojaCD.Domain.Entity;
    using LojaCD.Services.ViewModels;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<GeneroMusicalViewModel, GeneroMusical>().ReverseMap();
            CreateMap<ArtistaViewModel, Artista>().ReverseMap();

            CreateMap<CDViewModel, CD>().ReverseMap();
            CreateMap<MusicaViewModel, Musica>().ReverseMap();

        }
    }

}
