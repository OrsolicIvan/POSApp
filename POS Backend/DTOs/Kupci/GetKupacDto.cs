namespace POS_Backend.DTOs.Kupci
{
    public class GetKupacDto
    {
        public int Id { get; set; }
        public int Sifra { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public string Mjesto { get; set; }
        //public List<ZAGLAVLJE_RACUNA> ZaglavljeRacuna { get; set; }
    }
}
