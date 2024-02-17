using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Door Shape", menuName = "Scriptable Objects/Doors/New Door Shape")]
public class DoorShape : DoorTraitBase
{
    [field: SerializeField]
    public Sprite Sprite { get; private set; }

    [field: SerializeField]
    public DoorShapeOption Shape { get; private set; }

    public override string GetRuleText() => $"From here on out, I remember the correct doors all being {RuleName.ToUpper()} shape too!";
}

