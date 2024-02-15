using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RuleCanvas : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _ruleText;

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
        }

        _ruleText.text = latestRule.GetRuleText();
    }
}
