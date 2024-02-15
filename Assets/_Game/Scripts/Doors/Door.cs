using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public DoorTraitsModel Traits { get; private set; } = new DoorTraitsModel();

    [SerializeField]
    private GameObject _woodGrainGameObject;

    private SpriteRenderer _spriteRenderer;
    private SpriteRenderer _woodGrainRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _woodGrainRenderer = _woodGrainGameObject.GetComponent<SpriteRenderer>();
    }

    public void SetTraits(DoorTraitsModel traits)
    {
        Traits = traits;
        
        SetSprite();
        SetColor();
        SetWoodGrain();
    }

    private void SetWoodGrain()
    {
        if (Traits.WoodGrain == null)
        {
            return;
        }

        _woodGrainRenderer.sprite = Traits.WoodGrain.Sprite;
    }

    private void SetSprite()
    {
        if (Traits.Shape == null)
        {
            return;
        }

        _spriteRenderer.sprite = Traits.Shape.Sprite;
    }

    private void SetColor()
    {
        if (Traits.Color == null)
        {
            return;
        }

        _spriteRenderer.color = Traits.Color.Color;
    }
}
