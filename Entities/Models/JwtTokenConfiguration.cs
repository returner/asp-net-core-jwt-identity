using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Interfaces
{
    public record JwtTokenConfiguration
    {
        TimeSpan ExpireInterval { get; set; }
    }
}
