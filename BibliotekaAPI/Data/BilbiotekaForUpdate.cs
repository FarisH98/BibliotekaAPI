using System.ComponentModel.DataAnnotations;

namespace BibliotekaAPI.Data
{
    public class BilbiotekaForUpdate
    {
        [Key]
        public int Id { get; set; }
        public string Naziv { get; set; }
        public double BrojRadnika { get; set; }
        public string RadniDani { get; set; }
        public double MjesecnaClanarina { get; set; }
    }
}
