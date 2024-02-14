using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Door Shape", menuName = "Scriptable Objects/Doors/New Door Shape")]
public class DoorShape : DoorTraitBase
{
    // [field: SerializeField]
    // public List<Sprite> Sprites { get; private set; } = new List<Sprite>();

    [field: SerializeField]
    public Sprite Sprite { get; private set; }
}

