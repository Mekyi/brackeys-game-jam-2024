using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playGame()
    {
        AudioManager.Instance.PlayOneShot(FMODEvents.Instance.ButtonClick, transform.position);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
