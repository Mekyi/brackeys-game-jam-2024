using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMODEvents : MonoBehaviour
{
    [field: Header("BGM")]
    [field: SerializeField]
    public EventReference BGM { get; private set; }


    [field: Header("SFX")]

    [field: SerializeField]
    public EventReference DoorOpen { get; private set; }

    [field: SerializeField]
    public EventReference ButtonClick { get; private set; }

    public static FMODEvents Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        Instance = this;
    }
}
