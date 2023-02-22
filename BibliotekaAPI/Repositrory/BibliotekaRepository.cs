using Microsoft.AspNetCore.Mvc.ViewFeatures;
using static BibliotekaAPI.Repositrory.BibliotekaRepository;
using System.IO.Pipelines;
using BibliotekaAPI.Data;

namespace BibliotekaAPI.Repositrory
{
    {
        public class BibliotekaRepository : IBibliotekaRepository
        {

            private readonly BibliotekaContext _context;
            


            public BibliotekaRepository(BibliotekaContext context)
            {

                _context = context ?? throw new ArgumentNullException(nameof(context));
                
            }

            public async Task<IEnumerable<Biblioteka>> GetBibliotekasAsync()
            {
                return await _context.Bibliotekas.ToListAsync();
            }

            public async Task AddBibliotekaAsync(Biblioteka biblioteka)
            {
                await _context.Bibliotekas.AddAsync(biblioteka);
                await _context.SaveChangesAsync();
            }

            public async Task<Biblioteka?> GetBibliotekaByIdAsync(int id)
            {
                return await _context.Bibliotekas.Where(x => x.Id == id).FirstOrDefaultAsync();
            }

            public void DeleteBiblioteka(Biblioteka biblioteka)
            {
                _context.Bibliotekas.Remove(biblioteka);
                _context.SaveChanges();
            }

            public async Task UpdateBibliotekaAsync(Biblioteka currentBiblioteka, BibliotekaForUpdate newBiblioteka)
            {
                _mapper.Map(newBiblioteka, currentBiblioteka);
                await _context.SaveChangesAsync();
            }

            public async Task<Biblioteka?> GetBestRatedBiblioteka()
            {
                return await _context.Bibliotekas.OrderByDescending(x => x.Naziv).FirstOrDefaultAsync();
            }


        }
    }


