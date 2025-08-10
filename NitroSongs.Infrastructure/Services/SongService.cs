using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NitroSongs.ApplicationLayer.UseCases.Songs;
using NitroSongs.Common.Common;
using NitroSongs.Common.Dtos;
using NitroSongs.Domain.Entities;
using NitroSongs.Infrastructure.Extensions;
using NitroSongs.Infrastructure.Persistence.Contexts;

namespace NitroSongs.Infrastructure.Services
{
    public class SongService : ISongService
    {
        private readonly NitroSongsDbContext _context;
        public SongService(NitroSongsDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<PagedResult<Song>>> GetPagedAsync(int page, int size)
        {
            var res = await _context.Songs
                .Include(s => s.Author)
                .Include(s => s.Rhythm)
                .Include(s => s.Tone)
                .Include(s => s.Genre)
                    .GetPagedAsync(page, size);
            
            return ServiceResponse<PagedResult<Song>>.Success(res);
        }
    }
}
