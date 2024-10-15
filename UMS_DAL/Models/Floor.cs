using System;
using System.Collections.Generic;

namespace UMS_DAL.Models;

public partial class Floor
{
    public int FloorId { get; set; }

    public int BuildingId { get; set; }

    public string FloorName { get; set; } = null!;

    public virtual Building Building { get; set; } = null!;

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
