using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Door Color", menuName = "Scriptable Objects/Doors/New Door Color")]
public class DoorColor : DoorTraitBase
{
    [field: SerializeField]
    public Color Color { get; private set; }

    public override string GetRuleText() => $"Door must be <color=#{Color.ToHexString()}>{RuleName.ToUpper()}</color> color";
}
