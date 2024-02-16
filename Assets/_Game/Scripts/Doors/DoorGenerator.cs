using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class DoorGenerator : MonoBehaviour
{
    public static DoorGenerator Instance { get; private set; }

    [SerializeField]
    private bool _testMode = false;

    [SerializeField]
    private float _demoInterval = 1f;

    [SerializeField]
    private List<DoorColor> _availableColors = new List<DoorColor>();

    [SerializeField]
    private List<DoorShape> _availableShapes = new List<DoorShape>();

    [SerializeField]
    private List<WoodGrain> _availableWoodGrains = new List<WoodGrain>();

    [SerializeField]
    private GameObject _doorBasePrefab;

    [SerializeField]
    private List<Transform> _doorSpots = new List<Transform>(5);

    private List<GameObject> _currentDoors = new List<GameObject>();

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        if (_testMode == false)
        {
            _availableColors.Clear();
            _availableShapes.Clear();
            _availableWoodGrains.Clear();
        }
    }

    private void Start()
    {
        if (_testMode)
        {
            StartCoroutine(DemoDoors());
        }
    }

    public DoorTraitsModel GenerateRound(RoundConfiguration roundConfiguration, DoorTraitsModel currentRules)
    {

        if (_currentDoors.Any())
        {
            foreach (var door in _currentDoors)
            {
                Destroy(door);
            }

        }

        AddTraitsToPool(roundConfiguration.TraitPoolAdditions);

        switch (roundConfiguration.NewRule)
        {
            case RuleOption.None:
                RuleManager.Instance.SetLatestRule(null);
                break;
            case RuleOption.Color:
                currentRules.Color = GetRandomTrait<DoorColor>() as DoorColor;
                RuleManager.Instance.SetLatestRule(currentRules.Color);
                break;
            case RuleOption.Shape:
                currentRules.Shape = GetRandomTrait<DoorShape>() as DoorShape;
                RuleManager.Instance.SetLatestRule(currentRules.Shape);
                break;
            case RuleOption.Grain:
                currentRules.WoodGrain = GetRandomTrait<WoodGrain>(currentRules.Shape.Shape) as WoodGrain;
                RuleManager.Instance.SetLatestRule(currentRules.WoodGrain);
                break;
            default:
                break;
        }

        var doors = new List<GameObject>();

        var correctDoor = GenerateDoor(currentRules);
        doors.Add(correctDoor);

        if (roundConfiguration.DoorsToGenerate > 1)
        {
            // We already have the correct door so we start from +1 index 
            for (int i = 1; i < roundConfiguration.DoorsToGenerate; i++)
            {
                doors.Add(GenerateDoor());
            }
        }

        _currentDoors = doors;
        PlaceDoors(doors);

        return currentRules;
    }

    private void PlaceDoors(List<GameObject> doors)
    {
        
        var randomizedDoors = doors.OrderBy(_ => Guid.NewGuid()).ToList();
        
        for (int i = 0; i < randomizedDoors.Count; i++)
        {
            randomizedDoors[i].transform.position = _doorSpots[i].transform.position;
        }

        // TODO better randomization?
        // TODO test with different numbers of doors -> did that, it worked
    }

    private GameObject GenerateDoor(DoorTraitsModel correctDoorRules = null)
    {
        var newDoorObject = Instantiate(_doorBasePrefab);
        var door = newDoorObject.GetComponent<Door>();

        DoorTraitsModel doorTraitsModel = new DoorTraitsModel();

        // If correct door rules are set, we are generating traits for the correct door
        // Otherwise we randomize traits for doors
        doorTraitsModel.Color = correctDoorRules?.Color ?? GetRandomTrait<DoorColor>() as DoorColor;
        doorTraitsModel.Shape = correctDoorRules?.Shape ?? GetRandomTrait<DoorShape>() as DoorShape; 
        doorTraitsModel.WoodGrain = correctDoorRules?.WoodGrain ?? GetRandomTrait<WoodGrain>(doorTraitsModel.Shape.Shape) as WoodGrain; 

        door.SetTraits(doorTraitsModel);

        return newDoorObject;
    }

    private IEnumerator DemoDoors()
    {
        while (true)
        {
            var generatedDoor = GenerateDoor();
            
            yield return new WaitForSeconds(_demoInterval);

            Destroy(generatedDoor);
        }
    }

    private void AddTraitsToPool(List<DoorTraitBase> newAvailableTraits)
    {
        foreach (var trait in newAvailableTraits)
        {
            var traitType = trait.GetType();

            if (traitType == typeof(DoorColor))
            {
                _availableColors.Add(trait as DoorColor);
            }
            else if (traitType == typeof(DoorShape))
            {
                _availableShapes.Add(trait as DoorShape);
            }
            else if (traitType == typeof(WoodGrain))
            {
                _availableWoodGrains.Add(trait as WoodGrain);
            }
            else
            {
                Debug.LogWarning($"There's not existing trait pool for type {trait.GetType()}");
            }
        }
    }

    private DoorTraitBase GetRandomTrait<T>(DoorShapeOption doorShape = DoorShapeOption.Rectangle)
    {
        // TODO Refactor to be more generic
        var traitType = typeof(T);
        DoorTraitBase randomTrait = null;

        try
        {
            if (traitType == typeof(DoorColor))
            {
                randomTrait = _availableColors[Random.Range(0, _availableColors.Count)];
            }
            else if (traitType == typeof(DoorShape))
            {
                randomTrait = _availableShapes[Random.Range(0, _availableShapes.Count)];
            }
            else if (traitType == typeof(WoodGrain))
            {
                var shapeGrains = _availableWoodGrains.Where(grain => grain.Shape == doorShape).ToList();

                randomTrait = shapeGrains[Random.Range(0, shapeGrains.Count)];
            }
            else
            {
                Debug.LogWarning($"There's not existing trait pool for type {traitType}");
                return default;
            }
        }
        catch (ArgumentOutOfRangeException ex)
        {
            // This is a bad way to catch and silence error that is thrown if trait pool doesn't have any available traits. Should be refactored
        }

        return randomTrait;
    }

}

