using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModel.DataTransfers
{
    public record UserDtoRequest (string Username, string Password);
}
