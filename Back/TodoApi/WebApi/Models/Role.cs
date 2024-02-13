using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class Role
{
    public int RoleId { get; set; }

    public int UserId { get; set; }

    public virtual RolesInfo RoleNavigation { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
