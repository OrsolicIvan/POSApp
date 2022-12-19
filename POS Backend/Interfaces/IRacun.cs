using POS_Backend.DTOs.Proizvod;
using POS_Backend.DTOs.Racun.Creating;
using POS_Backend.DTOs.Racun.Getting;
using POS_Backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POS_Backend.Interfaces
{
    public interface IRacun
    {
        Task CreateRacun(ZaglavljeRacunaDto racunDto); 
        Task<IEnumerable<GetZaglavljeRacunaDto>> GetAllZaglavlja();
        Task DeleteRacun(int id);
        Task<IEnumerable<GetJedinicaDto>> GetJedinice();

    }
}
