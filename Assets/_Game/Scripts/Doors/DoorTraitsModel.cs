using System;
using System.Collections;
using System.Collections.Generic;

public class DoorTraitsModel
{
    public DoorShape Shape { get; set; }

    public DoorColor Color { get; set; }

    public WoodGrain WoodGrain { get; set; }

    public DoorStickers StickerSettings { get; set; }

    public DoorHandle DoorHandle { get; set; }

    public bool DoorEquals(DoorTraitsModel rules)
    {

        if (rules.Shape?.Shape != null && Shape?.Shape != rules.Shape?.Shape) return false;
        if (Color?.Color != rules.Color?.Color && rules.Color?.Color != null) return false;
        if (rules.WoodGrain != null && WoodGrain?.RuleName != rules.WoodGrain?.RuleName) return false;
        if (rules.StickerSettings != null && StickerSettings.StickerAmount !=  rules.StickerSettings.StickerAmount) return false;
        if (rules.DoorHandle != null && (DoorHandle?.SpriteLeft != rules.DoorHandle?.SpriteLeft) || DoorHandle?.SpriteRight != rules.DoorHandle?.SpriteRight) return false;

        return true;
    }

}
