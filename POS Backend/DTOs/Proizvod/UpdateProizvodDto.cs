using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS_Backend.DTOs.Proizvod
{
    public class UpdateProizvodDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Naziv { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public decimal Cijena { get; set; }
        [Required]
        public int Stanje { get; set; }
        public int JedinicaId { get; set; }
        
    }
}
