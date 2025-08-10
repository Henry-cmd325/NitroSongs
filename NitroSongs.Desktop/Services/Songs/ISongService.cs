using NitroSongs.Common.Common;
using NitroSongs.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NitroSongs.Services.Songs
{
    public interface ISongService
    {
        public Task<PagedResult<SongDto>> GetSongs(int page, int size);
    }
}
