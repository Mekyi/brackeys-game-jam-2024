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

    [field: SerializeField]
    public GameObject DoorsParent { get; private set; }

    public static event Action<GameState> OnGameStateChanged;

    [SerializeField]
    private GameObject victory_Screen;

    [SerializeField]
    private GameObject lose_Screen;

    [SerializeField]
    private TextMeshProUGUI Time_Left;

    public int CurrentRound { get; private set; } = 0;

    private float remainingTime = 0;

    private TextMeshProUGUI gameOverText;

    public string GameOverReason { get; private set; }

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
        gameOverText = lose_Screen.GetComponentInChildren<TextMeshProUGUI>();
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateGameState(GameState.StartRound);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameState == GameState.SelectDoor)
        {
            CheckTimerStatus();
            CheckDoorSelect();
        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void UpdateGameState(GameState newState)
    {
        GameState = newState;

        switch (GameState)
        {
            case GameState.StartRound:
                HandleStartRound();
                DoorsParent.SetActive(false);
                break;
            case GameState.SelectDoor:
                DoorsParent.SetActive(true);
                break;
            case GameState.Victory:
                remainingTime = 0;
                break;
            case GameState.Lose:
                gameOverText.text = GameOverReason;
                remainingTime = 0;
                break;
        }

        OnGameStateChanged?.Invoke(newState);
    }

    public void SetRoundTime(float roundTime)
    {
        remainingTime = roundTime;
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
        AudioManager.Instance.PlayOneShot(FMODEvents.Instance.ButtonClick, transform.position);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void CheckTimerStatus()
    {
        if (RuleManager.Instance.RoundConfigurations.Count > CurrentRound && GameState == GameState.SelectDoor)
        {
            remainingTime = remainingTime - Time.deltaTime;

            if (remainingTime > 0)
            {
                int seconds = Mathf.FloorToInt(remainingTime % 60);
                //float milliSeconds = (remainingTime % 1) * 1000;

                if (seconds < 10)
                {
                    Time_Left.text = string.Format("{0:00} S", seconds);
                }
                else
                {
                    Time_Left.text = string.Format("{0:00} S", seconds);
                }
            }
            else
            {
                Time_Left.text = string.Format("00 S");
                UpdateGameState(GameState.Lose);
            }
        }
    }
    

    private void CheckDoorSelect()
    {
        if (Input.GetMouseButtonDown(0) && GameState == GameState.SelectDoor)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray.origin, ray.direction, out RaycastHit hitInfo)) // When a door is clicked, the game tells you whether it's the correct door or not
            {
                AudioManager.Instance.PlayOneShot(FMODEvents.Instance.DoorOpen, transform.position);
                DoorTraitsModel results = hitInfo.transform.GetComponent<Door>().Traits;

                if (results != null)
                {
                    if (Right_Or_Wrong(results))
                    {
                        CurrentRound += 1;

                        if (RuleManager.Instance.RoundConfigurations.Count < CurrentRound + 1)
                        {
                            UpdateGameState(GameState.Victory);
                            return;
                        }

                        UpdateGameState(GameState.StartRound);
                    }
                    else
                    {
                        UpdateGameState(GameState.Lose);
                    }
                }
            }
        }
    }

    public void SetGameOverReason(string reason)
    {
        GameOverReason = "GAME OVER\n Lost in the maze\n " + reason;
    }
}
