using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModel.Contracts.Request
{
    public record CreateGroupRequest(string GroupName, string? Description);
}
