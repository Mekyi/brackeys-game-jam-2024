using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class Door : MonoBehaviour
{
    public DoorTraitsModel Traits { get; private set; } = new DoorTraitsModel();

    [SerializeField]
    private GameObject _woodGrainGameObject;

    [SerializeField]
    private List<Sprite> _doorStickers = new List<Sprite>();

    [SerializeField]
    private List<SpriteRenderer> _stickerPositions = new List<SpriteRenderer>();

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
        SetStickers();
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

    private void SetStickers()
    {
        var stickerSettigns = Traits.StickerSettings;

        if (stickerSettigns == null)
        {
            return;
        }

        if (stickerSettigns.StickerAmount == 0)
        {
            return;
        }

        List<Sprite> stickersToUse = new List<Sprite>();

        // Randomize used stickers
        for (int i = 0; i < stickerSettigns.StickerAmount; i++)
        {
            stickersToUse.Add(_doorStickers[Random.Range(0, _doorStickers.Count)]);
        }

        // Place stickers
        for (int i = 0; i < stickersToUse.Count; i++)
        {
            _stickerPositions[i].sprite = stickersToUse[i];
        }

        Debug.Log(Traits.StickerSettings.StickerAmount);
    }
}
