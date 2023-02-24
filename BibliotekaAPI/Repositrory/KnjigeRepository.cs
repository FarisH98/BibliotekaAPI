using BibliotekaAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace BibliotekaAPI.Repositrory
{
    public class KnjigeRepository : IKnjigeRepository
    {

        private readonly BibliotekaContext _context;
        private BibliotekaContext _context1;


        public KnjigeRepository(BibliotekaContext context)
        {

            _context = context ?? throw new ArgumentNullException(nameof(context));

        }

        public async Task<IEnumerable<Knjige>> GetKnjigesAsync()
        {
            return await _context.Knjiges.ToListAsync();
        }

        public async Task AddKnjigeAsync(Knjige knjige)
        {
            await _context.Knjiges.AddAsync(knjige);
            await _context.SaveChangesAsync();
        }

        public async Task<Knjige?> GetKnjigeByIdAsync(int id)
        {
            return await _context.Knjiges.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public void DeleteKnjige(Knjige knjige)
        {
            _context.Knjiges.Remove(knjige);
            _context.SaveChanges();
        }

        public void UpdateKnjige(Knjige knjige)
        {
            _context.Set<Knjige>().Update(knjige);
        }

        public void Update(Knjige knjige)
        {
            throw new NotImplementedException();
        }
    }
}