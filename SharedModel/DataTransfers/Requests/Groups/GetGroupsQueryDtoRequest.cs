using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModel.DataTransfers.Requests.Groups
{
    public record GetGroupsQueryDtoRequest(int pageIndex, int pageSize);
}
