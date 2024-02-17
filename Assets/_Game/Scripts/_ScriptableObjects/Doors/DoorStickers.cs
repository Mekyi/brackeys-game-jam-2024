using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Door Sticker Configuration", menuName = "Scriptable Objects/Doors/New Door Sticker Configuration")]
public class DoorStickers : DoorTraitBase
{
    [field: SerializeField]
    public int MinStickerAmount { get; private set; } = 1;

    [field: SerializeField]
    public int MaxStickerAmount { get; private set; } = 8;

    public int StickerAmount { get; private set; }

    public void SetAmount(int amount)
    {
        StickerAmount = amount;
    }

    public override string GetRuleText() => $"I recall there being {StickerAmount} stickers above the correct doors too!";
}
