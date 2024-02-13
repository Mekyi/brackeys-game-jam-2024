using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Round Configuration", menuName = "Scriptable Objects/Rounds/New Round Configuration")]
public class RoundConfiguration : ScriptableObject
{
    [field: SerializeField]
    public RuleOption NewRule { get; private set; }

    // TODO Replace rule

    // TODO Show new rule time

    // TODO Door select time
}
