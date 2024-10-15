using System;
using System.Collections.Generic;

namespace UMS_DAL.Models;

public partial class Gender
{
    public int GenderId { get; set; }

    public string Description { get; set; } = null!;
}
