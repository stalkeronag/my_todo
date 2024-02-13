using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string HashPass { get; set; } = null!;

    public string? Phone { get; set; }
}
