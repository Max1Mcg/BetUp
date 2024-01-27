using System;
using System.Collections.Generic;

namespace BetUp.DbModels;

public partial class Role
{
    public Guid Id { get; set; }

    public string? Name { get; set; }
}
