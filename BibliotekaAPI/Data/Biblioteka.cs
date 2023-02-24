using System.ComponentModel.DataAnnotations;

namespace BibliotekaAPI.Data
{
    public class Biblioteka
    {
        [Key]
        public int Id { get; set; }
        public string Naziv { get; set; }
        public double BrojRadnika { get; set; }
        public double RadniDani { get; set; }
        public double MjesecnaClanarina { get; set; }   
        
    }
}
