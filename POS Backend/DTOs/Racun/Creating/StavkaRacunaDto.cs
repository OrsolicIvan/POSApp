using POS_Backend.DTOs.Proizvod;
using System.ComponentModel.DataAnnotations;

namespace POS_Backend.DTOs.Racun.Creating
{
    public class StavkaRacunaDto
    {
        [Required]
        public string Naziv { get; set; }
        [Required]
        public int Kolicina { get; set; }
        [Required]
        public decimal Cijena { get; set; }
        public double? Popust { get; set; }
        public decimal IznosPopusta { get; set; }
        [Required]
        public decimal Vrijednost { get; set; }
        [Required]
        public int ProizvodId { get; set; }
    }
}
