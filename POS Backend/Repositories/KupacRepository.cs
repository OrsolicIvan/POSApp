using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POS_Backend.DTOs.Kupci;
using POS_Backend.Interfaces;
using POS_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS_Backend.Repositories
{
    public class KupacRepository : GenericRepository<Kupac>, IKupac
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        public KupacRepository(Context context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<ActionResult<IEnumerable<GetKupacDto>>> GetAllKupci()
        {
            return await _context.Kupci.ProjectTo<GetKupacDto>(_mapper.ConfigurationProvider).ToListAsync();

        }
        public async Task DeleteKupac(int id)
        {
            var kupac = await _context.Kupci.FirstOrDefaultAsync(u => u.Id == id);
            _context.Kupci.Remove(kupac);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateKupac(UpdateKupacDto kupacDto)
        {
            var kupac = await _context.Kupci.Where(u => u.Id == kupacDto.Id).SingleOrDefaultAsync();
            if (kupac != null)
            {
                kupac.Naziv = kupacDto.Naziv;
                kupac.Adresa = kupacDto.Adresa;
                kupac.Mjesto = kupacDto.Mjesto;

            }
            if (kupac == null)
            {
                throw new Exception("Film nije pronadjen");
            }

            await _context.SaveChangesAsync();
        }


    }
}
