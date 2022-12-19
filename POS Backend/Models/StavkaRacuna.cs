using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS_Backend.Models
{
    public class StavkaRacuna
    {
        [Key]
        public int Id { get; set; }
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
        public int ZaglavljeRacunaId { get; set; }
        [Required]
        public ZaglavljeRacuna ZaglavljeRacuna { get; set; }
        
        [Required]
        public int ProizvodId { get; set; }
        public Proizvod Proizvod { get; set; }

    }
}
