using BibliotekaAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace BibliotekaAPI.Repositrory
{
    
        public class RadniciRepository : IRadniciRepository
        {

            private readonly BibliotekaContext _context;
            private BibliotekaContext _context1;


            public RadniciRepository(BibliotekaContext context)
            {

                _context = context ?? throw new ArgumentNullException(nameof(context));

            }

            public async Task<IEnumerable<Radnici>> GetRadnicisAsync()
            {
                return await _context.Radnicis.ToListAsync();
            }

            public async Task AddRadniciAsync(Radnici radnici)
            {
                await _context.Radnicis.AddAsync(radnici);
                await _context.SaveChangesAsync();
            }

            public async Task<Radnici?> GetRadniciByIdAsync(int id)
            {
                return await _context.Radnicis.Where(x => x.Id == id).FirstOrDefaultAsync();
            }

            public void DeleteRadnici(Radnici radnici)
            {
                _context.Radnicis.Remove(radnici);
                _context.SaveChanges();
            }

            public void UpdateRadnici(Radnici radnici)
            {
                _context.Set<Radnici>().Update(radnici);
            }

            public void Update(Radnici radnici)
            {
                throw new NotImplementedException();
            }
        }
    }
