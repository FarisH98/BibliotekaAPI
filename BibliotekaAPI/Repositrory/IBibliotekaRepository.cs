using BibliotekaAPI.Data;
using System.IO.Pipelines;

namespace BibliotekaAPI.Repositrory
{
    public interface IBibliotekaRepository
    { 
        Task<IEnumerable<Biblioteka>> GetBibliotekasAsync();

        Task AddBibliotekaAsync(Biblioteka biblioteka);

        Task<Biblioteka?> GetBibliotekaByIdAsync(int id);

        void DeleteBiblioteka(Biblioteka biblioteka);

        void Update(Biblioteka biblioteka);


    }
}
