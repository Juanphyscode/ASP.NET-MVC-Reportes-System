using System;
using System.Collections.Generic;

namespace ReportesMVC.Models;

public partial class Usuario
{
    public int Iidpersona { get; set; }

    public string Password { get; set; } = null!;

    public virtual Persona IidpersonaNavigation { get; set; } = null!;
}
