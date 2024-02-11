using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ChangeSprite(Sprite sprite)
    {
        _spriteRenderer.sprite = sprite;
    }

    public void ChangeColor(Color color)
    {
        _spriteRenderer.color = color;
    }
}
