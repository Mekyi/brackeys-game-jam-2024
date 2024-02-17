using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Door Handle", menuName = "Scriptable Objects/Doors/New Door Handle")]
public class DoorHandle : DoorTraitBase
{
    [field: SerializeField]
    public Sprite SpriteLeft { get; private set; }

    [field: SerializeField]
    public Sprite SpriteRight { get; private set; }

    public override string GetRuleText() => $"The correct doors should from here onwards also have a {RuleName.ToUpper()} handle!";
}

