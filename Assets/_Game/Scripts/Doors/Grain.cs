using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grain : MonoBehaviour
{
    private SpriteRenderer _grainRenderer;

    private void Awake()
    {
        _grainRenderer = GetComponent<SpriteRenderer>();
    }

    private void SetGrain(Sprite sprite)
    {
        _grainRenderer.sprite = sprite;
    }
}
