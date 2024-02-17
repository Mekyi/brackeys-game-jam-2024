using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Door Wood Grain", menuName = "Scriptable Objects/Doors/New Door Wood Grain")]
public class WoodGrain : DoorTraitBase
{
    [field: SerializeField]
    public Sprite Sprite { get; private set; }

    [field: SerializeField]
    public DoorShapeOption Shape { get; private set; }

    [field: SerializeField]
    public Difficulty Difficulty { get; private set; }

    public override string GetRuleText() => $"I believe now the doors we need to take all also have a {RuleName.ToUpper()} hidden in them?";
}
