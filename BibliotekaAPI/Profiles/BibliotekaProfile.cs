using System.IO.Pipelines;

namespace BibliotekaAPI.Profiles
{

   public class BibliotekaProfile : Profile
    {
        public BibliotekaProfile()
        {

            CreateMap<BibliotekaForUpdate, Biblioteka>();
            CreateMap<BibliotekaForUpdate, Biblioteka>();

        }
    }
}
