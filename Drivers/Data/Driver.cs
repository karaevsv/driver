using System;
using System.Collections.Generic;

namespace Drivers.Data;

/// <summary>
/// 	
/// </summary>
public partial class Driver
{
    public int Id { get; set; }

    public string Guid { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string? Patronimic { get; set; }

    public string PasportSerial { get; set; } = null!;

    public string PasportNumber { get; set; } = null!;

    public string RegistrationCity { get; set; } = null!;

    public string RegistrationAddress { get; set; } = null!;

    public string LivingCity { get; set; } = null!;

    public string LivingAddress { get; set; } = null!;

    public string? WorkPlace { get; set; }

    public string? WorkRole { get; set; }

    public string MobPhone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int PhotoId { get; set; }

    public string? Description { get; set; }

    public virtual Photo Photo { get; set; } = null!;
}
