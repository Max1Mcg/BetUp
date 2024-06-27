using BetUp.CommonInterfaces;
using System;
using System.Collections.Generic;

namespace BetUp.DbModels;

public partial class Role: BaseObject
{
    public string? Name { get; set; }

    public bool? IsDeleted { get; set; }

    public string? Description { get; set;}
}
