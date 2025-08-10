using Microsoft.Extensions.Options;
using NitroSongs.Common.Common;
using NitroSongs.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NitroSongs.Services.Songs
{
    public class SongsService : ISongService
    {
        private readonly ApiService _api;
        private readonly IOptions<Configuration> _config;
        public SongsService(ApiService api, IOptions<Configuration> config)
        {
            _api = api;
            _config = config;
        }

        public async Task<PagedResult<SongDto>> GetSongs(int page, int size)
        {
            var res = await _api.GetAsync<PagedResult<SongDto>>($"{_config.Value.SongEndpoint}?page={page}&size={size}");

            return res;
        }
    }
}
