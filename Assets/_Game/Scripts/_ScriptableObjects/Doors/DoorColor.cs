using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Door Color", menuName = "Scriptable Objects/Doors/New Door Color")]
public class DoorColor : DoorTraitBase
{
    [field: SerializeField]
    public Color Color { get; private set; }
}
