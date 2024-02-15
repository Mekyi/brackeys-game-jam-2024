using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager Instance { get; private set; }

    public GameState GameState { get; private set; }

    public static event Action<GameState> OnGameStateChanged;

    [SerializeField]
    private GameObject victory_Screen;

    [SerializeField]
    private GameObject lose_Screen;

    [SerializeField]
    private TextMeshProUGUI Time_Left;

    public int CurrentRound { get; private set; } = 0;

    private int TimeLeft { get; } = 0;

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

    // Start is called before the first frame update
    void Start()
    {
        UpdateGameState(GameState.StartRound);
    }

    // Update is called once per frame
    void Update()
    {

        // timer (current issue: Time does not reset at the beginning of a round)
        if (RuleManager.Instance.RoundConfigurations.Count > CurrentRound) { 

            float remainingTime = RuleManager.Instance.RoundConfigurations[CurrentRound].TimeLeft - Time.timeSinceLevelLoad;

            if (remainingTime > 0) {
                int seconds = Mathf.FloorToInt(remainingTime % 60);
                int milliSeconds = Mathf.FloorToInt(remainingTime * 1000) % 1000; // Idk if this is right btw, I just copied it online

                if (milliSeconds < 100)
                {
                    Time_Left.text = string.Format("{0:00}:0{1:0}", seconds, milliSeconds);
                } else
                {
                    Time_Left.text = string.Format("{0:00}:{1:0}", seconds, milliSeconds);
                }

            } else
            {
              Time_Left.text = string.Format("00:000");
              // UpdateGameState(GameState.Lose);
            }
        } else
        {
            Time_Left.text = string.Format(""); // removes countdown when there are no more rounds left
        }
        

        if (Input.GetMouseButtonDown(0) && GameState == GameState.SelectDoor)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray.origin, ray.direction, out RaycastHit hitInfo)) // When a door is clicked, the game tells you whether it's the correct door or not
            {
                DoorTraitsModel results = hitInfo.transform.GetComponent<Door>().Traits;

                if (results != null)
                {
                    if (Right_Or_Wrong(results))
                    {
                        CurrentRound += 1;
                        UpdateGameState(GameState.StartRound);
                        print("right door");
                    } else
                    {
                        //UpdateGameState(GameState.Lose);
                        print("wrong door");
                    }

                }


            }
        }
    }

    public void UpdateGameState(GameState newState)
    {
        GameState = newState;

        switch (GameState)
        {
            case GameState.StartRound:
                HandleStartRound();
                //UpdateGameState(GameState.SelectDoor);
                break;
            case GameState.SelectDoor:
                break;
            case GameState.Victory: // TODO set victory UI to show up when victory happens
                break;
            case GameState.Lose: // TODO set lose screen to show up when loss happens
                break;
        }

        OnGameStateChanged?.Invoke(newState);
    }

    private void HandleStartRound()
    {
        // Game should end if there's no round configuration for the current round
        if (RuleManager.Instance.RoundConfigurations.Count < CurrentRound + 1)
        {
            UpdateGameState(GameState.Victory);
            return;
        }

        RuleManager.Instance.SetupRound(CurrentRound);
    }

    bool Right_Or_Wrong(DoorTraitsModel doorTraits)
    {
        return doorTraits.DoorEquals(RuleManager.Instance.ActiveRules);
    }

    public void Reset_Game()
    {
        lose_Screen.SetActive(false);
        victory_Screen.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        print("reset");
    }
}
