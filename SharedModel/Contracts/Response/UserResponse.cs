using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModel.Contract.Response
{
    public record UserResponse
    {
        public int Id { get; set; }
        public string? Username { get; set; }
    }
}
