using AutoMapper;
using NitroSongs.Common.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace NitroSongs.ApplicationLayer.Extensions
{
    public static class ServiceResponseExtensions
    {
        public static ServiceResponse<PagedResult<TDest>> MapPaged<TSource, TDest>(
            this ServiceResponse<PagedResult<TSource>> source,
            IMapper mapper)
        {
            return new ServiceResponse<PagedResult<TDest>>
            {
                IsSuccess = source.IsSuccess,
                Message = source.Message,
                Data = new PagedResult<TDest>
                {
                    Items = mapper.Map<List<TDest>>(source.Data!.Items),
                    TotalCount = source.Data.TotalCount,
                    PageNumber = source.Data.PageNumber,
                    PageSize = source.Data.PageSize
                }
            };
        }
    }
}
