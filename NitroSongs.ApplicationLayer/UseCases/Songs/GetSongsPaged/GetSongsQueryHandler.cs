using AutoMapper;
using Cortex.Mediator.Queries;
using NitroSongs.ApplicationLayer.Extensions;
using NitroSongs.ApplicationLayer.UseCases.Queries;
using NitroSongs.Common.Common;
using NitroSongs.Common.Dtos;
using NitroSongs.Domain.Entities;
using System.Drawing;

namespace NitroSongs.ApplicationLayer.UseCases.Songs.GetSongsPaged
{
    public class GetSongsQueryHandler : IQueryHandler<GetPagedQuery<SongDto>, ServiceResponse<PagedResult<SongDto>>>
    {
        private readonly ISongService _songService;
        private readonly IMapper _mapper;
        public GetSongsQueryHandler(ISongService songService, IMapper mapper)
        {
            _songService = songService;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<PagedResult<SongDto>>> Handle(GetPagedQuery<SongDto> query, CancellationToken cancellationToken)
        {
            var res = await _songService.GetPagedAsync(query.Page, query.Size);

            var mapped = res.MapPaged<Song, SongDto>(_mapper);

            return mapped;
        }
    }
}
