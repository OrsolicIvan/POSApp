using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS_Backend.Models
{
    [Index(nameof(Sifra), IsUnique = true)]
    public class Proizvod
    {
        [Key]
        public int Id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Sifra { get; set; }
        [Required]
        public string Naziv { get; set; }
        [Required]
        public decimal Cijena { get; set; }
        [Required]
        public int Stanje { get; set; }
        public List<StavkaRacuna> StavkeRacuna {get;set;}
        public int JedinicaId { get; set; }
        public JedinicaMjere JedinicaMjere { get; set; }
    }
}
