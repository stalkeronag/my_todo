using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class RolesInfo
{
    public int RoleId { get; set; }

    public string Title { get; set; } = null!;
}
