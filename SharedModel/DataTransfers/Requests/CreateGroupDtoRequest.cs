﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModel.DataTransfers.Requests
{
    public record CreateGroupDtoRequest(string GroupName, string? Description);
}
