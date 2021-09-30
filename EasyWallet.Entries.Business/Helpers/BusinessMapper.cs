using AutoMapper;
using EasyWallet.Entries.Business.Models;
using EasyWallet.Entries.Data.Entities;
using System;

namespace EasyWallet.Entries.Business.Helpers
{
    internal static class BusinessMapper
    {
        public static IMapper Mapper => Lazy.Value;

        public static T Map<T>(object source) => Mapper.Map<T>(source);

        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var configuration = new MapperConfiguration(config =>
            {
                config.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                config.AddProfile<MapperProfile>();
            });

            return configuration.CreateMapper();
        });

        private class MapperProfile : Profile
        {
            public MapperProfile() => CreateMap<EntryData, Entry>().ReverseMap();
        }
    }
}
