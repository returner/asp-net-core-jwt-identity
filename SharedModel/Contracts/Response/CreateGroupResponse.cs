using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModel.Contracts.Response
{
    public record CreateGroupResponse(int Id, string Name, string? Description, DateTime Created);
}
