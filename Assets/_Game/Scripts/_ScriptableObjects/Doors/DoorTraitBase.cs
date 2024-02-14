using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTraitBase : ScriptableObject
{
    [field: SerializeField]
    public string RuleName { get; private set; }
}
