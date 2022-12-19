using POS_Backend.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS_Backend.DTOs.Racun.Creating
{
    public class ZaglavljeRacunaDto
    {
        [Required]
        public DateTime Datum { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Napomena { get; set; }
        [Required]
        public int KupacId { get; set; }
        public List<StavkaRacunaDto> StavkeRacuna { get; set; }
        public decimal UkupnaCijena { get; set; }
        }
}
