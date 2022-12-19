using System;
namespace POS_Backend.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IKupac Kupci { get; }
        IProizvod Proizvodi { get; }
        IRacun Racuni { get; }
        int Complete();
    }
}
