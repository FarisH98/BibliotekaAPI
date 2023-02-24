using BibliotekaAPI.Data;

namespace BibliotekaAPI.Repositrory
{
    public interface IKnjigeRepository
    {
        Task<IEnumerable<Knjige>> GetKnjigesAsync();

        Task AddKnjigeAsync(Knjige knjige);

        Task<Knjige?> GetKnjigeByIdAsync(int id);

        void DeleteKnjige(Knjige knjige);

        void Update(Knjige knjige);


    }
}
