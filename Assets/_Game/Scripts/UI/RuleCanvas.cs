using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RuleCanvas : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _ruleText;

    [SerializeField]
    private GameObject _ruleImageObject;

    private RuleImage _ruleImage;

    private void Awake()
    {
        _ruleImage = _ruleImageObject.GetComponent<RuleImage>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Game_Manager.Instance.UpdateGameState(GameState.SelectDoor);
        }
    }

    private void OnEnable()
    {
        var latestRule = RuleManager.Instance.LatestRule;

        if (latestRule == null)
        {
            Game_Manager.Instance.UpdateGameState(GameState.SelectDoor);
            return;
        }

        _ruleText.text = latestRule.GetRuleText();

        var ruleType = latestRule.GetType();

        if (ruleType == typeof(DoorColor))
        {
            _ruleImage.VisualizeColor((latestRule as DoorColor).Color);
        }
        else if (ruleType == typeof(DoorShape))
        {
            _ruleImage.VisualizeShape((latestRule as DoorShape).Shape);
        }
        else if (ruleType == typeof(WoodGrain))
        {
            _ruleImage.VisualizeGrain((latestRule as WoodGrain).RuleName);
        }
        else if (ruleType == typeof(DoorStickers))
        {
            _ruleImage.VisualizeStickers();
        }
        else if (ruleType == typeof(DoorHandle))
        {
            _ruleImage.VisualizeHandle((latestRule as DoorHandle).RuleName);
        }
        else
        {
            Debug.LogWarning($"{ruleType.GetType()} type visualization not configured");
        }
    }
}
