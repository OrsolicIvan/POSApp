using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POS_Backend.DTOs.Proizvod;
using POS_Backend.Interfaces;
using POS_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS_Backend.Repositories
{
    public class ProizvodRepository : GenericRepository<Proizvod>, IProizvod
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        public ProizvodRepository(Context context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<ActionResult<IEnumerable<GetProizvodDto>>> GetAllProizvodi()
        {
            return await _context.Proizvodi.ProjectTo<GetProizvodDto>(_mapper.ConfigurationProvider).ToListAsync();

        }
        public async Task DeleteProizvod(int id)
        {
            var proizvod = await _context.Proizvodi.FirstOrDefaultAsync(u => u.Id == id);
            _context.Proizvodi.Remove(proizvod);
            await _context.SaveChangesAsync();
        }
        public async Task CreateProizvod(CreateProizvodDto proizvodDto)
        {
            var jedinica = _context.JediniceMjere.Where(i => i.Id == proizvodDto.JedinicaId).FirstOrDefault();
            var proizvod = new Proizvod
            {
                Naziv = proizvodDto.Naziv,
                Cijena = proizvodDto.Cijena,
                JedinicaId = proizvodDto.JedinicaId,
                Stanje = proizvodDto.Stanje,
                JedinicaMjere = jedinica,
            };
            await _context.Proizvodi.AddAsync(proizvod);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateProizvod(UpdateProizvodDto proizvodDto)
        {
            var proizvod = await _context.Proizvodi.Where(u => u.Id == proizvodDto.Id).SingleOrDefaultAsync();
            var jedinica = await _context.JediniceMjere.Where(u => u.Id == proizvodDto.JedinicaId).SingleOrDefaultAsync();
            if (proizvod != null)
            {
                proizvod.Naziv = proizvodDto.Naziv;
                proizvod.Cijena = proizvodDto.Cijena;
                proizvod.Stanje = proizvodDto.Stanje;
                proizvod.JedinicaId = proizvodDto.JedinicaId;
                proizvod.JedinicaMjere = jedinica;
            }
            if (proizvod == null)
            {
                throw new Exception("Film nije pronadjen");
            }

            await _context.SaveChangesAsync();
        }
        
    }
}
