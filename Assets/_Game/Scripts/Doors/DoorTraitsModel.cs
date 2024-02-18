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

        if (rules.Shape?.Shape != null && Shape?.Shape != rules.Shape?.Shape)
        {
            Game_Manager.Instance.SetGameOverReason("That door was not " + rules.Shape?.RuleName.ToUpper() + " shaped!");
            return false;
        }
        if (Color?.Color != rules.Color?.Color && rules.Color?.Color != null)
        {
            Game_Manager.Instance.SetGameOverReason("That door was not " + rules.Color?.RuleName.ToUpper() + "!");
            return false;
        }
        if (rules.WoodGrain != null && WoodGrain?.RuleName != rules.WoodGrain?.RuleName)
        {
            Game_Manager.Instance.SetGameOverReason("That door didn't have a " + rules.WoodGrain?.RuleName.ToUpper() + "!");
            return false;
        }
        if (rules.StickerSettings != null && StickerSettings.StickerAmount !=  rules.StickerSettings.StickerAmount)
        {
            Game_Manager.Instance.SetGameOverReason("That door didn't have " + rules.StickerSettings.StickerAmount + " stickers!");
            return false;
        }
        if (rules.DoorHandle != null && (DoorHandle?.SpriteLeft != rules.DoorHandle?.SpriteLeft) || DoorHandle?.SpriteRight != rules.DoorHandle?.SpriteRight)
        {
            Game_Manager.Instance.SetGameOverReason("That door did not have a " + rules.DoorHandle.RuleName.ToUpper() + "!");
            return false;
        }

        return true;
    }

}
