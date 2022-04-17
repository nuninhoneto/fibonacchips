using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public ObjectPoolingSystem poolSystem;
    public float TimeToSpawn = 1;
    public Vector3 SpawnPosition;
    public Vector3 SpawnOffsetPosition;

    float m_nextSpawnTime;
    SpawnBehaviour spawnBehaviour;

    void Start()
    {
        if (spawnBehaviour == null)
            spawnBehaviour = new FibonnaciSpawnBehaviour(this);

        m_nextSpawnTime = float.MinValue;
    }

    void Update()
    {
        if (Time.time >= m_nextSpawnTime)
        {
            spawnBehaviour.Spawn(CreateGameObject);
            m_nextSpawnTime = Time.time + TimeToSpawn;
        }
    }

    GameObject CreateGameObject()
    {
        GameObject newGameObject = poolSystem.RetrieveGameObject();

        if (newGameObject != null)
            AppData.Instance.CreateGameObject();

        return newGameObject;
    }
}
