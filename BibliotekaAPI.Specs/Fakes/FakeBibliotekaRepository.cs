using BibliotekaAPI.Data;
using BibliotekaAPI.Repositrory;
using System;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaAPI.Specs.Fakes
{
    public class FakeBibliotekaRepository : IBibliotekaRepository
    {
        private readonly Dictionary<int, Biblioteka> _bibliotekaDictionary = new();

        public Task AddBibliotekaAsync(Biblioteka biblioteka)
        {
            biblioteka.Id = _bibliotekaDictionary.Count + 1;
            _bibliotekaDictionary.Add(biblioteka.Id, biblioteka);
            return Task.CompletedTask;
        }

        public void DeleteBiblioteka(Biblioteka biblioteka)
        {
            _bibliotekaDictionary.Remove(biblioteka.Id);
        }

        public Task<Biblioteka?> GetBibliotekaByIdAsync(int id)
        {
            return Task.FromResult(_bibliotekaDictionary[id]);
        }

        public Task<IEnumerable<Biblioteka>> GetBibliotekasAsync()
        {
            var result = _bibliotekaDictionary.Values.ToArray();
            return Task.FromResult(result.AsEnumerable());
        }

        public async Task UpdateBibliotekaAsync(Biblioteka currentBiblioteka, BibliotekaForUpdate newBiblioteka)
        {
            var biblioteka = await GetBibliotekaByIdAsync(currentBiblioteka.Id);
            biblioteka.Naziv = newBiblioteka.Naziv;
            biblioteka.BrojRadnika = newBiblioteka.BrojRadnika;
            biblioteka.RadniDani = newBiblioteka.RadniDani;
            biblioteka.MjesecnaClanarina = newBiblioteka.MjesecnaClanarina;
        }

        void IBibliotekaRepository.Update(Biblioteka biblioteka)
        {
            throw new NotImplementedException();
        }
    }
}
