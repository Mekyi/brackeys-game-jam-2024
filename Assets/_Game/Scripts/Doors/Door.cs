using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public DoorTraits Traits { get; private set; }

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetTraits(DoorTraits traits)
    {
        Traits = traits;
        
        SetSprite(traits.Shape.Sprite);
        SetColor(traits.Color.Color);
    }

    private void SetSprite(Sprite sprite)
    {
        _spriteRenderer.sprite = sprite;
    }

    private void SetColor(Color color)
    {
        _spriteRenderer.color = color;
    }
}
