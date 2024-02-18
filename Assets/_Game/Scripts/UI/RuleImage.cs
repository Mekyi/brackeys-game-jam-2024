using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RuleImage : MonoBehaviour
{
    [SerializeField] 
    private GameObject _ruleBubbleObject;

    [SerializeField]
    private Sprite _bubbleSprite;


    [Header("Stickers")]

    [SerializeField]
    private Sprite _stickersSprite;


    [Header("Grains")]

    [SerializeField]
    private Sprite _grainCatSprite;

    [SerializeField]
    private Sprite _grainStarSprite;

    [SerializeField]
    private Sprite _grainHeartSprite;


    [Header("Colors")]

    [SerializeField]
    private Sprite _colorSprite;


    [Header("Shapes")]

    [SerializeField]
    private Sprite _rectangleShape;

    [SerializeField]
    private Sprite _ovalShape;

    
    [Header("Handles")]

    [SerializeField]
    private Sprite _knobHandle;

    [SerializeField]
    private Sprite _leverHandle;

    [SerializeField]
    private Sprite _pullHandle;

    
    private Image _image;

    private Image _bubbleImage;


    public void VisualizeColor(Color color)
    {
        ResetImage();
        _ruleBubbleObject.SetActive(true);
        _image.sprite = _bubbleSprite;
        _bubbleImage.sprite = _colorSprite;
        _bubbleImage.color = color;
    }

    public void VisualizeShape(DoorShapeOption shape)
    {
        ResetImage();
        _ruleBubbleObject.SetActive(true);
        _image.sprite = _bubbleSprite;
        _bubbleImage.color = Color.white;

        switch (shape)
        {
            case DoorShapeOption.Rectangle:
                _bubbleImage.sprite = _rectangleShape;
                break;
            case DoorShapeOption.Oval:
                _bubbleImage.sprite = _ovalShape;
                break;
            default:
                break;
        }
    }

    public void VisualizeGrain(string grainName)
    {
        ResetImage();
        _ruleBubbleObject.SetActive(false);

        switch (grainName)
        {
            case "Cat":
                _image.sprite = _grainCatSprite;
                break;
            case "Star":
                _image.sprite = _grainStarSprite;
                break;
            case "Heart":
                _image.sprite = _grainHeartSprite;
                break;
            default:
                Debug.Log($"{grainName} visualization not set");
                break;
        }
    }

    public void VisualizeHandle(string knobName)
    {
        ResetImage();
        _ruleBubbleObject.SetActive(true);
        _image.sprite = _bubbleSprite;
        _bubbleImage.color = Color.white;

        switch (knobName)
        {
            case "Pull":
                _bubbleImage.sprite = _pullHandle;
                break;
            case "Knob":
                _bubbleImage.sprite = _knobHandle;
                break;
            case "Lever":
                _bubbleImage.sprite = _leverHandle;
                break;
            default:
                break;
        }

    }

    public void VisualizeStickers()
    {
        ResetImage();
        _ruleBubbleObject.SetActive(false);
        _image.sprite = _stickersSprite;
    }

    private void ResetImage() 
    {
        _image = GetComponent<Image>();
        _bubbleImage = _ruleBubbleObject.GetComponent<Image>();
    }
}
