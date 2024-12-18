﻿using Simulator.Maps;
using Simulator;
using System.Drawing;

public class Birds : Animals
{
    public override char MapSymbol => CanFly ? 'B' : 'b';
    public bool CanFly { get; set; } = true;

    public override string Info
    {
        get => $"{Description} ({(CanFly ? "fly+" : "fly-")}) <{Size}>";
    }
    protected override Point GetNewPosition(Direction direction) => CanFly
            ? Map.Next(Map.Next(Position, direction), direction)
            : Map.NextDiagonal(Position, direction);
}