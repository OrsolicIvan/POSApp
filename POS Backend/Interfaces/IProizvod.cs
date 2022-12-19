using Microsoft.AspNetCore.Mvc;
using POS_Backend.DTOs.Proizvod;
using POS_Backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POS_Backend.Interfaces
{
    public interface IProizvod:IGenericRepository<Proizvod>
    {
        Task CreateProizvod(CreateProizvodDto proizvodDto);
        Task<ActionResult<IEnumerable<GetProizvodDto>>> GetAllProizvodi();
        Task DeleteProizvod(int id);
        Task UpdateProizvod(UpdateProizvodDto proizvodDto);
    }
}
