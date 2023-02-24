using AutoMapper;
using BibliotekaAPI.Data;
using BibliotekaAPI.Repositrory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.IO.Pipelines;

namespace BibliotekaAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BibliotekaController : ControllerBase
    {
        private readonly IBibliotekaRepository _bibliotekaRepository;
        private BibliotekaContext _context;

        public BibliotekaController(IBibliotekaRepository bibliotekaRepository)
        {
            _bibliotekaRepository = bibliotekaRepository ?? throw new ArgumentNullException(nameof(bibliotekaRepository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Biblioteka>>> DobaviSvaBibliotekas()
        {
            var result = await _bibliotekaRepository.GetBibliotekasAsync();
            return Ok(result);
        }

        [HttpPost]
        public async void DodajBiblioteka([FromBody] Biblioteka BibliotekaZaDodati)
        {
            await _bibliotekaRepository.AddBibliotekaAsync(BibliotekaZaDodati);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> IzbrisiBiblioteka(int id)
        {
            var result = await _bibliotekaRepository.GetBibliotekaByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            _bibliotekaRepository.DeleteBiblioteka(result);

            return Ok($"Pice sa ovim id {id} je pobrisano.");
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<Biblioteka>> DobaviBiblioteka(int id)
        {
            var biblioteka = await _bibliotekaRepository.GetBibliotekaByIdAsync(id);
            if (biblioteka == null)
            {
                return NotFound();
            }
            return Ok(biblioteka);
        }
    }
}
