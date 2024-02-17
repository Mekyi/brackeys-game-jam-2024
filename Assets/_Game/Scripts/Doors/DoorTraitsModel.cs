using System;
using System.Collections;
using System.Collections.Generic;

public class DoorTraitsModel
{
    public DoorShape Shape { get; set; }

    public DoorColor Color { get; set; }

    public WoodGrain WoodGrain { get; set; }

    public bool DoorEquals(DoorTraitsModel rules)
    {

        if (rules.Shape?.Shape != null && Shape?.Shape != rules.Shape?.Shape) return false;
        if (Color?.Color != rules.Color?.Color && rules.Color?.Color != null) return false;
        if (rules.WoodGrain != null && WoodGrain?.RuleName != rules.WoodGrain?.RuleName) return false;

        return true;
    }

}
