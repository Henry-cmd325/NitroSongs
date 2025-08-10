using NitroSongs.Common.Common;
using NitroSongs.Common.Dtos;
using NitroSongs.Domain.Entities;

namespace NitroSongs.ApplicationLayer.UseCases.Songs
{
    public interface ISongService
    {
        public Task<ServiceResponse<PagedResult<Song>>> GetPagedAsync(int page, int size);
    }
}
