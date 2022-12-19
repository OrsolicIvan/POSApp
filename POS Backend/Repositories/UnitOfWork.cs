using AutoMapper;
using POS_Backend.Interfaces;
using POS_Backend.Models;
using Microsoft.AspNetCore.Identity;
using POS_Backend.Repositories;

namespace FilmBACKEND.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        public UnitOfWork(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            Proizvodi = new ProizvodRepository(_context, _mapper);
            Kupci = new KupacRepository(_context, _mapper);
            Racuni = new RacunRepository(_context, _mapper);
        }
        public IProizvod Proizvodi{ get; private set; }
        public IKupac Kupci { get; private set; }
        public IRacun Racuni { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
