using Cortex.Mediator.Queries;
using NitroSongs.Common.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NitroSongs.ApplicationLayer.UseCases.Queries
{
    public class GetPagedQuery<T> : IQuery<ServiceResponse<PagedResult<T>>>
    {
        public int Page { get; set; } = 1;
        public int Size { get; set; } = 10;
        public GetPagedQuery(int page = 1, int size = 10)
        {
            Page = page;
            Size = size;
        }
    }
}
