using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS_Backend.DTOs.Kupci
{
    public class UpdateKupacDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Naziv { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Adresa { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Mjesto { get; set; }
    }
}
