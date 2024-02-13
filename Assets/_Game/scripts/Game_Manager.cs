using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    [SerializeField]
    private GameObject victory_Screen;

    [SerializeField]
    private GameObject lose_Screen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null) // When a door is clicked, the game tells you whether it's the correct door or not
            {
                bool result = hit.collider.gameObject.GetComponent<Door_action>().DoorChosen();
                Right_Or_Wrong(result);

            }
        }
    }

    bool Right_Or_Wrong(bool result)
    {
        if (result)
        {
            victory_Screen.SetActive(true);
        } else
        {
            lose_Screen.SetActive(true);
        }
        return result;
    }

    public void Reset_Game()
    {
        lose_Screen.SetActive(false);
        victory_Screen.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        print("reset");
    }
}
