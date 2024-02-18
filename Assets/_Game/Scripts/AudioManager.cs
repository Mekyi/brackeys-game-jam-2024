using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    private List<EventInstance> _eventInstances;
    private List<StudioEventEmitter> _studioEventEmitters;
    private EventInstance _bgmEventInstance;

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

        _eventInstances = new List<EventInstance>();
        _studioEventEmitters = new List<StudioEventEmitter>();
    }

    private void Start()
    {
        InitializaBGM(FMODEvents.Instance.BGM);
    }

    public void PlayOneShot(EventReference sound, Vector3 worldPosition)
    {
        RuntimeManager.PlayOneShot(sound, worldPosition);
    }

    public EventInstance CreateInstance(EventReference eventReference)
    {
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
        _eventInstances.Add(eventInstance);

        return eventInstance;
    }

    public StudioEventEmitter InitializeEventEmitter(EventReference eventReference, GameObject emitterGameObject)
    {
        StudioEventEmitter emitter = emitterGameObject.GetComponent<StudioEventEmitter>();
        emitter.EventReference = eventReference;
        _studioEventEmitters.Add(emitter);

        return emitter;
    }

    private void InitializaBGM(EventReference bgmEventReference)
    {
        _bgmEventInstance = CreateInstance(bgmEventReference);
        _bgmEventInstance.start();
    }

    private void OnDestroy()
    {
        CleanEventInstances();
    }

    private void CleanEventInstances()
    {
        foreach (var eventInstance in _eventInstances)
        {
            eventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            eventInstance.release();
        }

        foreach (var emitter in _studioEventEmitters)
        {
            emitter.Stop();
        }
    }
}
