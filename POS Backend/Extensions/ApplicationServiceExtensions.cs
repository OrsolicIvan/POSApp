
using FilmBACKEND.Repositories;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using POS_Backend.Helpers;
using POS_Backend.Interfaces;
using POS_Backend.Models;
using POS_Backend.Repositories;
using POS_Backend.Services;

namespace POS_Backend.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<FormOptions>(o =>
            {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IProizvod, ProizvodRepository>();
            services.AddScoped<IKupac, KupacRepository>();
            services.AddScoped<IRacun, RacunRepository>();
            services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
            services.AddDbContext<Context>(options =>
            options.UseNpgsql(config.GetConnectionString("DevConnection")));
            return services;
        }
    }
}
