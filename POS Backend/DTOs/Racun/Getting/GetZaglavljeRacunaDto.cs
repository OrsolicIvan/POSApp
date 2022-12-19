using POS_Backend.DTOs.Kupci;
using POS_Backend.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS_Backend.DTOs.Racun.Getting
{
    public class GetZaglavljeRacunaDto
    {
        public int Id { get; set; }
        public int Sifra { get; set; }
        public int Broj { get; set; }
        [Required]
        public DateTime Datum { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Napomena { get; set; }
        [Required]
        public int KupacId { get; set; }
        public GetKupacDto Kupac { get; set; }
        public List<GetStavkaRacunaDto> StavkeRacuna { get; set; }
        public decimal UkupnaCijena { get; set; }
    }
}
