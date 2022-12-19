using Microsoft.AspNetCore.Mvc;
using POS_Backend.DTOs.Kupci;
using POS_Backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POS_Backend.Interfaces
{
    public interface IKupac:IGenericRepository<Kupac>
    {
        Task<ActionResult<IEnumerable<GetKupacDto>>> GetAllKupci();
        Task DeleteKupac(int id);
        Task UpdateKupac(UpdateKupacDto kupacDto);
    }
}
