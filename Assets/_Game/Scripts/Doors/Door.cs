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
    private GameObject _doorFrame;

    [SerializeField] 
    private Sprite _ovalFrame;
    
    [SerializeField]
    private GameObject _woodGrainGameObject;

    [SerializeField]
    private GameObject _doorLeftHandleGameObject;

    [SerializeField]
    private GameObject _doorRightHandleGameObject;

    [SerializeField]
    private List<Sprite> _doorStickers = new List<Sprite>();

    [SerializeField]
    private List<SpriteRenderer> _stickerPositions = new List<SpriteRenderer>();

    private SpriteRenderer _spriteRenderer;
    private SpriteRenderer _woodGrainRenderer;
    private SpriteRenderer _doorLeftHandleRenderer;
    private SpriteRenderer _doorRightHandleRenderer;
    private SpriteRenderer _frameRenderer;

    private bool _isDoorOpened = false;
    private bool _isFrameDetached = false;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _woodGrainRenderer = _woodGrainGameObject.GetComponent<SpriteRenderer>();
        _doorLeftHandleRenderer = _doorLeftHandleGameObject.GetComponent<SpriteRenderer>();
        _doorRightHandleRenderer = _doorRightHandleGameObject.GetComponent<SpriteRenderer>();
        _frameRenderer = _doorFrame.GetComponent<SpriteRenderer>();
        Game_Manager.OnGameStateChanged += OnGameStateChanged;
        //transform.parent.rotation = Quaternion.Euler(0f, 0f, 0f);
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }

    private void OnMouseOver()
    {
        _isDoorOpened = true;
    }

    private void OnMouseExit()
    {
        _isDoorOpened = false;
    }

    private void Update()
    {
        transform.parent.rotation = Quaternion.Euler(0f, 0f, 0f);

        Debug.Log(_isDoorOpened);

        if (_isDoorOpened == false)
        {
            transform.parent.rotation = Quaternion.Euler(0f, 0f, 0f);
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else
        {
            transform.parent.rotation = Quaternion.Euler(0f, 6f, 0f);
        }
    }

    private void OnDestroy()
    {
        Game_Manager.OnGameStateChanged -= OnGameStateChanged;
        Destroy(_doorFrame);
    }

    private void OnGameStateChanged(GameState state)
    {
        if (state == GameState.SelectDoor)
        {
            _doorFrame.transform.SetParent(Game_Manager.Instance.transform, true);
            _isFrameDetached = true;
            _doorFrame.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }

    private void OpenDoor(bool shouldDoorBeOpen)
    {
        if (shouldDoorBeOpen && _isDoorOpened == false)
        {
            transform.parent.rotation = Quaternion.Euler(0f, 6f, 0f);
            _isDoorOpened = true;
        }
        else if (shouldDoorBeOpen == false && _isDoorOpened)
        {
            transform.parent.rotation = Quaternion.identity;
        }
    }

    public void SetTraits(DoorTraitsModel traits)
    {
        Traits = traits;
        
        SetSprite();
        SetColor();
        SetWoodGrain();
        SetStickers();
        SetHandle();
    }

    private void SetHandle()
    {
        if (Traits.DoorHandle == null)
        {
            return;
        }

        // Doors hinges are currently only on the left side so handle side randomization should be disabled until right side hinge is implemented
        //var isHandleLeft = Random.value > 0.5f;

        //if (isHandleLeft)
        //{
        //    _doorRightHandleGameObject.SetActive(false);
        //    _doorLeftHandleGameObject.SetActive(true);
        //    _doorLeftHandleRenderer.sprite = Traits.DoorHandle.SpriteLeft;
        //}
        //else
        //{
        //    _doorLeftHandleGameObject.SetActive(false);
        //    _doorRightHandleGameObject.SetActive(true);
        //    _doorRightHandleRenderer.sprite = Traits.DoorHandle.SpriteRight;
        //}

        _doorLeftHandleGameObject.SetActive(false);
        _doorRightHandleGameObject.SetActive(true);
        _doorRightHandleRenderer.sprite = Traits.DoorHandle.SpriteRight;
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

        if (Traits.Shape.Shape == DoorShapeOption.Oval)
        {
            _frameRenderer.sprite = _ovalFrame;
        }
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
    }
}
