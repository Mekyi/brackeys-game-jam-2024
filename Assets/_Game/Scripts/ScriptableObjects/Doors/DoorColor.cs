using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Door Color", menuName = "ScriptableObjects/Doors/Door Color")]
public class DoorColor : DoorTraitBase
{
    [SerializeField]
    public Color Color { get; set; }
}
