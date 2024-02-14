using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

[CreateAssetMenu(fileName = "Round Configuration", menuName = "Scriptable Objects/Rounds/New Round Configuration")]
public class RoundConfiguration : ScriptableObject
{
    [field: SerializeField]
    public RuleOption NewRule { get; private set; }

    [field: SerializeField]
    [Description("Door traits to add into the pool that is used to generate the doors")]
    public List<DoorTraitBase> TraitPoolAdditions {  get; private set; }

    [field: SerializeField]
    [field: Range(1, 5)]
    public int DoorsToGenerate { get; private set; } = 1;

    // TODO Replace rule

    // TODO Wood grain difficulty

    // TODO Wood grain flip randomized

    // TODO Show new rule time

    // TODO Door select time
}
