using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS_Backend.DTOs.Proizvod
{
    public class CreateProizvodDto
    {
        [Required]
        public string Naziv { get; set; }
        [Required]
        public decimal Cijena { get; set; }
        [Required]
        public int Stanje { get; set; }
        [Required]
        public int JedinicaId { get; set; }
    }
}
