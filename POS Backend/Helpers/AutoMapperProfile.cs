using AutoMapper;
using POS_Backend.DTOs.Kupci;
using POS_Backend.DTOs.Proizvod;
using POS_Backend.DTOs.Racun.Creating;
using POS_Backend.DTOs.Racun.Getting;
using POS_Backend.DTOs.User;
using POS_Backend.Models;

namespace POS_Backend.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AppUser, RegisterDto>().ReverseMap();
            CreateMap<AppUser, LoginDto>().ReverseMap();
            CreateMap<Proizvod, CreateProizvodDto>().ReverseMap();
            CreateMap<Proizvod, GetProizvodDto>().ReverseMap();
            CreateMap<Kupac, CreateKupacDto>().ReverseMap();
            CreateMap<Kupac, GetKupacDto>().ReverseMap();
            CreateMap<Proizvod, UpdateProizvodDto>().ReverseMap();
            CreateMap<Kupac, UpdateKupacDto>().ReverseMap();
            CreateMap<ZaglavljeRacuna, GetZaglavljeRacunaDto>().ReverseMap();
            CreateMap<StavkaRacuna, GetStavkaRacunaDto>().ReverseMap();
            CreateMap<Kupac, GetKupacDto1>().ReverseMap();
            CreateMap<ZaglavljeRacuna, ZaglavljeRacunaDto>().ReverseMap();
            CreateMap<StavkaRacuna, StavkaRacunaDto>().ReverseMap();
            CreateMap<JedinicaMjere, GetJedinicaDto>().ReverseMap();


        }
    }
}
    