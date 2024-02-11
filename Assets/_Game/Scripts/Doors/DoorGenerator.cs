using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DoorGenerator : MonoBehaviour
{
    [SerializeField]
    private bool _testMode = false;

    [SerializeField]
    private float _demoInterval = 1f;

    [SerializeField]
    private List<DoorColor> _availableColors = new List<DoorColor>();

    [SerializeField]
    private List<DoorShape> _availableShapes = new List<DoorShape>();

    [SerializeField]
    private GameObject _doorBasePrefab;


    private void Start()
    {
        if (_testMode)
        {
            StartCoroutine(DemoDoors());
        }
    }

    private GameObject GenerateDoor()
    {
        var newDoorObject = Instantiate(_doorBasePrefab);
        var door = newDoorObject.GetComponent<Door>();

        DoorColor randomColor = _availableColors[Random.Range(0, _availableColors.Count)];
        DoorShape randomShape = _availableShapes[Random.Range(0, _availableShapes.Count)];

        DoorTraits doorTraits = new(
            color: randomColor, 
            shape: randomShape
        );

        door.SetTraits(doorTraits);

        return newDoorObject;
    }

    public IEnumerator DemoDoors()
    {
        while (true)
        {
            var generatedDoor = GenerateDoor();
            
            yield return new WaitForSeconds(_demoInterval);

            Destroy(generatedDoor);
        }
    }
}
