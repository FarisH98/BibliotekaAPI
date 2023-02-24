using AutoMapper;
using BibliotekaAPI.Data;

namespace BibliotekaAPI.Profiles
{
     public class RadniciProfile : Profile
    {
        public RadniciProfile()
        {

            CreateMap<RadniciForUpdate, Radnici>();
            CreateMap<RadniciForUpdate, Radnici>();

        }
    }
}

