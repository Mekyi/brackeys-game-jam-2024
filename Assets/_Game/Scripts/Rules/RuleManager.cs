using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuleManager : MonoBehaviour
{
    public static RuleManager Instance { get; private set; }

    [field: SerializeField]
    public List<RoundConfiguration> RoundConfigurations {  get; private set; } = new List<RoundConfiguration>();

    public DoorTraitsModel ActiveRules { get; private set; } = new DoorTraitsModel();

    public DoorTraitBase LatestRule { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void SetupRound(int roundNumber)
    {
        var roundConfiguration = RoundConfigurations[roundNumber];

        var updatedRules  = DoorGenerator.Instance.GenerateRound(roundConfiguration, ActiveRules);

        ActiveRules = updatedRules;
    }

    public void SetLatestRule(DoorTraitBase latestRule)
    {
        LatestRule = latestRule;
    }
}
