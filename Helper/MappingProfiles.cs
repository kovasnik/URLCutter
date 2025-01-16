using AutoMapper;
using URLCutter.DTO;
using URLCutter.Models;

namespace URLCutter.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ShortUrlDTO, ShortURL>();
            CreateMap<ShortURL, ShortUrlDTO>();
            CreateMap<AddShortUrlDTO, ShortURL>();
            CreateMap<ShortURL, AddShortUrlDTO>();
        }
    }
}
