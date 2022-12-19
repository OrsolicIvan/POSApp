using System.Collections.Generic;

namespace POS_Backend.Models
{
    public class JedinicaMjere
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public List<Proizvod> Proizvodi { get; set; }
    }
}
