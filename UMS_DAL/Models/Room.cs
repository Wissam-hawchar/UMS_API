using System;
using System.Collections.Generic;

namespace UMS_DAL.Models;

public partial class Room
{
    public int RoomId { get; set; }

    public int FloorId { get; set; }

    public string RoomName { get; set; } = null!;

    public string RoomCapacity { get; set; } = null!;

    public virtual Floor Floor { get; set; } = null!;
}
