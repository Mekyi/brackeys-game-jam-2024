using System.Collections;
using System.Collections.Generic;

public class DoorTraits
{
    public DoorShape Shape { get; private set; }

    public DoorColor Color { get; private set; }

    public DoorTraits(DoorShape shape, DoorColor color)
    {
        Shape = shape;
        Color = color;
    }
}
