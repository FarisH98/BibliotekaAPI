using BibliotekaAPI.Data;
using Microsoft.AspNetCore.Mvc;

namespace BibliotekaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KnjigeController : ControllerBase
    {
        public  BibliotekaContext _context;

        public KnjigeController(BibliotekaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Knjige> DobaviSvaKnjiges()
        {
            var Knjige = _context.Knjiges.ToList();
            return Knjige;
        }

        [HttpPost]
        public void DodajKnjige([FromBody] Knjige KnjigeZaDodati)
        {
            _context.Knjiges.Add(KnjigeZaDodati);
            _context.SaveChanges();

        }

        [HttpDelete]
        public void IzbrisiKnjige([FromQuery] int Id)
        {
            var svaKnjige = _context.Knjiges.ToList();
            var knjige = svaKnjige.Where(x => x.Id == Id).FirstOrDefault();
            _context.Knjiges.Remove(knjige);
            _context.SaveChanges();


        }

        [HttpGet("{ID}")]
        public Knjige DobaviSvaKnjiges(int ID)
        {
            var knjige = _context.Knjiges.Where(x => x.Id == ID).FirstOrDefault();
            if (knjige != null)
            {
                return knjige;
            }
            return null;
        }
    }
}

