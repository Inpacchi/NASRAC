﻿using NASRAC.Models.Game.TeamEntities;

namespace NASRAC.Models.Game.Entities;

public class Car
{
    public int Id { get; set; }
    public int Number { get; set; }
    public Manufacturer Manufacturer { get; set; }
    public Team Team { get; set; }
}