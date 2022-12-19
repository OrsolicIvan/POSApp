using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS_Backend.Models
{
    public class Kupac
    {
        [Key]
        public int Id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Sifra { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Naziv { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Adresa { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Mjesto { get; set; }
        public List<ZaglavljeRacuna> ZaglavljeRacuna { get; set; }
    }
}
