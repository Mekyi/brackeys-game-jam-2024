using System;
using System.Collections;
using System.Collections.Generic;

public class DoorTraitsModel
{
    public DoorShape Shape { get; set; }

    public DoorColor Color { get; set; }

    public WoodGrain WoodGrain { get; set; }

    public DoorStickers StickerSettings { get; set; }

    public bool DoorEquals(DoorTraitsModel rules)
    {

        if (rules.Shape?.Shape != null && Shape?.Shape != rules.Shape?.Shape) return false;
        if (Color?.Color != rules.Color?.Color && rules.Color?.Color != null) return false;
        if (rules.WoodGrain != null && WoodGrain?.Sprite != rules.WoodGrain?.Sprite) return false;
        if (rules.StickerSettings != null && StickerSettings.StickerAmount !=  rules.StickerSettings.StickerAmount) return false;

        return true;
    }

}
