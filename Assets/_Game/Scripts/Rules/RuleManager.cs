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

    [field: SerializeField]
    public GameObject Wall {  get; private set; }

    private SpriteRenderer WallSpriteRenderer;

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
        WallSpriteRenderer = Wall.GetComponent<SpriteRenderer>();
    }

    public void SetupRound(int roundNumber)
    {
        var roundConfiguration = RoundConfigurations[roundNumber];

        var updatedRules  = DoorGenerator.Instance.GenerateRound(roundConfiguration, ActiveRules);

        ActiveRules = updatedRules;

        if (RoundConfigurations[roundNumber].Walltype != null)
        {
            WallSpriteRenderer.sprite = RoundConfigurations[roundNumber].Walltype;
        }
        
        Game_Manager.Instance.SetRoundTime(roundConfiguration.TimeLeft);
    }

    public void SetLatestRule(DoorTraitBase latestRule)
    {
        LatestRule = latestRule;
    }
}
