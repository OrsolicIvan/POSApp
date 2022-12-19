using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS_Backend.Models
{
    [Index(nameof(Broj), IsUnique = true)]
    public class ZaglavljeRacuna
    {
        [Key]
        public int Id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Broj { get; set; }
        [Required]
        public DateTime Datum { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Napomena { get; set; }
        [Required]
        public int KupacId { get; set; }
        public Kupac Kupac { get; set; }
        public List<StavkaRacuna> StavkeRacuna{ get; set; }
        public decimal UkupnaCijena { get; set; }
}
}
