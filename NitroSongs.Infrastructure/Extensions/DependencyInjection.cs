using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NitroSongs.ApplicationLayer.Mappings;
using NitroSongs.ApplicationLayer.UseCases.Songs;
using NitroSongs.Infrastructure.Persistence.Contexts;
using NitroSongs.Infrastructure.Services;

namespace NitroSongs.Infrastructure.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<NitroSongsDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
            );

            services.AddScoped<INitroSongContext, NitroSongsDbContext>();

            services.AddAutoMapper(cfg =>
            {
                cfg.AddMaps(typeof(SongProfile).Assembly);
            });

            services.AddScoped<ISongService, SongService>();

            return services;
        }
    }
}
