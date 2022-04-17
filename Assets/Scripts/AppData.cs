using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppData : MonoBehaviour
{
    public static AppData Instance;

    public int CreatedGameObjects { get; internal set; }
    public int DestroyedGameObjects { get; internal set; }
    public int ShowingGameObjects { get { return CreatedGameObjects - DestroyedGameObjects; } }

    public delegate void AppDataEventHandler();
    public event AppDataEventHandler OnCreateEvent;
    public event AppDataEventHandler OnDestroyedEvent;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CreateGameObject()
    {
        CreatedGameObjects++;

        if (OnCreateEvent != null)
            OnCreateEvent.Invoke();
    }

    public void DestroyGameObject()
    {
        DestroyedGameObjects++;

        if (OnDestroyedEvent != null)
            OnDestroyedEvent.Invoke();
    }
}
