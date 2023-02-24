using BibliotekaAPI.Data;

namespace BibliotekaAPI.Repositrory
{
    public interface IRadniciRepository
    {
        Task<IEnumerable<Radnici>> GetRadnicisAsync();

        Task AddRadniciAsync(Radnici radnici);

        Task<Radnici?> GetRadniciByIdAsync(int id);

        void DeleteRadnici(Radnici radnici);

        void Update(Radnici radnici);


    }
}
