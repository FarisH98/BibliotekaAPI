using System.ComponentModel.DataAnnotations;

namespace BibliotekaAPI.Data
{
    public class Knjige
    {
        [Key]
        public int Id { get; set; } 
        public string NazivKnjige { get; set; }
        public double MjesecnoIzdavana { get; set; }
        public string OpisKnjige { get; set; }
        
    }
}
