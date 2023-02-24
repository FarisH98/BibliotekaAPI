using BibliotekaAPI.Data;
using Microsoft.AspNetCore.Mvc;

namespace BibliotekaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RadniciController : ControllerBase
    {
        public BibliotekaContext _context;

        public RadniciController(BibliotekaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Radnici> DobaviSvaRadnicis()
        {
            var Radnici = _context.Radnicis.ToList();
            return Radnici;
        }

        [HttpPost]
        public void DodajRadnici([FromBody] Radnici RadniciZaDodati)
        {
            _context.Radnicis.Add(RadniciZaDodati);
            _context.SaveChanges();

        }

        [HttpDelete]
        public void IzbrisiRadnici([FromQuery] int Id)
        {
            var svaRadnici = _context.Radnicis.ToList();
            var radnici = svaRadnici.Where(x => x.Id == Id).FirstOrDefault();
            _context.Radnicis.Remove(radnici);
            _context.SaveChanges();


        }

        [HttpGet("{ID}")]
        public Radnici DobaviSvaRadnicis(int ID)
        {
            var radnici = _context.Radnicis.Where(x => x.Id == ID).FirstOrDefault();
            if (radnici != null)
            {
                return radnici;
            }
            return null;
        }
    }
}


