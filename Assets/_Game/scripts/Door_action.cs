using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_action : MonoBehaviour
{
    bool is_Correct_Door = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetMouseButtonDown(0)) {
            DoorChosen(); 
        } */ // Idk if I need this anymore
    }

    public bool DoorChosen()
    {
        return is_Correct_Door;
    }
}
