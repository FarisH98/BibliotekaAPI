using AutoMapper;
using BibliotekaAPI.Data;
using BibliotekaAPI.Repositrory;
using Microsoft.AspNetCore.Mvc;
using System.IO.Pipelines;

namespace BibliotekaAPI.Controllers
{
    
    
        [Route("api/[controller]")]
        [ApiController]
        public class BibliotekaController : ControllerBase
        {
            private readonly IBibliotekaRepository _bibliotekaRepository;
            private readonly IMapper _mapper;
            private readonly IRabbitMqSender _rabbitMqSender;

        public BibliotekaController(IBibliotekaRepository bibliotekaRepository)
            {
            _bibliotekaRepository = bibliotekaRepository ?? throw new ArgumentNullException(nameof(bibliotekaRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _rabbitMqSender = rabbitMqSender ?? throw new ArgumentNullException(nameof(rabbitMqSender));
        }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<Biblioteka>>> DobaviSvaBibliotekas()
            {
                var result = await _bibliotekaRepository.GetBibliotekasAsync();
            _rabbitMqSender.SendMessage(result);
            return Ok(result);
            }

            [HttpPost]
            public async Task<ActionResult<Biblioteka>> DodajBiblioteka(BibliotekaForCreation bibliotekaZaDodati)
            {
                var finalBiblioteka = _mapper.Map<Biblioteka>(bibliotekaZaDodati);
                await _bibliotekaRepository.GetBibliotekasAsync();
                _rabbitMqSender.SendMessage(finalBiblioteka);
                return CreatedAtAction(nameof(DobaviBiblioteka), new { id = finalBiblioteka.Id }, finalBiblioteka);
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
                _rabbitMqSender.SendMessage($"Biblioteka sa ovim id {id} je pobrisano.");

                return Ok($"Biblioteka sa ovim id {id} je pobrisano.");
            }
            [HttpGet("{id}")]
            public async Task<ActionResult<Biblioteka>> DobaviBiblioteka(int id)
            {
                var biblioteka = await _bibliotekaRepository.GetBibliotekaByIdAsync(id);
                if (biblioteka == null)
                {
                    return NotFound();
                }
                _rabbitMqSender.SendMessage(biblioteka);
                return Ok(biblioteka);
            }
            

            [HttpPut("{id}")]
            public async Task<IActionResult> AktualizirajBiblioteka(int id, [FromBody] BibliotekaForUpdate newBiblioteka)
            {
                var trenutnoBiblioteka = await _bibliotekaRepository.GetBibliotekaByIdAsync(id);
                if (trenutnoBiblioteka == null)
                {
                    return NotFound();
                }
                await _bibliotekaRepository.UpdateBibliotekaAsync(trenutnoBiblioteka, newBiblioteka);
                _rabbitMqSender.SendMessage($"The Biblioteka object with id {id} was updated.");
                return NoContent();
            }

        }
    }

