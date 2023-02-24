using AutoMapper;
using BibliotekaAPI.Data;

namespace BibliotekaAPI.Profiles
{
    public class KnjigeProfile : Profile
    {
        public KnjigeProfile()
        {

            CreateMap<KnjigeForUpdate, Knjige>();
            CreateMap<KnjigeForUpdate, Knjige>();

        }
    }
}

