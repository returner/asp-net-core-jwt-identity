﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModel.DataTransfers.Responses
{
    public record CreateGroupDtoResponse(int Id, string Name, string? Description, DateTime Created);
}
