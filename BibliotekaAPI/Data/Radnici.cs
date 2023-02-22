using System.ComponentModel.DataAnnotations;

namespace BibliotekaAPI.Data
{
    public class Radnici
    {
        [Key]
        public int Id { get; set; }
        public string NazivRadnika { get; set; }
        public double BrojRadnihSati { get; set; }
        public double Rejting { get; set; }
        public double Plata { get; set; }
        
    }
}
