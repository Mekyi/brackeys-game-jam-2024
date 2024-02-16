using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _ruleCanvas;

    [SerializeField]
    private GameObject _victoryScreen;

    [SerializeField]
    private GameObject _loseScreen;

    private void Awake()
    {
        Game_Manager.OnGameStateChanged += OnGameStateChanged;
    }

    private void OnDestroy()
    {
        Game_Manager.OnGameStateChanged -= OnGameStateChanged;
    }

    private void OnGameStateChanged(GameState state)
    {
        _ruleCanvas.SetActive(state == GameState.StartRound);
        _victoryScreen.SetActive(state == GameState.Victory);
        _loseScreen.SetActive(state == GameState.Lose);
    }
}
