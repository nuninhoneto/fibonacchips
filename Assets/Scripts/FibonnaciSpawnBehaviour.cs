using System.Collections.Generic;
using UnityEngine;

public class FibonnaciSpawnBehaviour : SpawnBehaviour
{
    Dictionary<int, int> m_fibonacciMemorization = new Dictionary<int, int>() { { 0, 0 }, { 1, 1 } };
    int m_counter = 1;

    public FibonnaciSpawnBehaviour(Spawner ownerSpawner) : base(ownerSpawner) { }

    public override void Spawn(CreateGameObject createGameObjectHandler)
    {
        int instancesToSpawn = CalcFibonacci(m_counter++);

        for (int i = 0; i < instancesToSpawn; i++)
        {
            GameObject gObj = createGameObjectHandler.Invoke();

            if (gObj != null)
            {
                gObj.transform.SetParent(null);
                gObj.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.farClipPlane / 2)) + (Owner.SpawnOffsetPosition * i);

                gObj.SetActive(true);
            }
        }
    }

    int CalcFibonacci(int n)
    {
        if (!m_fibonacciMemorization.ContainsKey(n))
            m_fibonacciMemorization.Add(n, CalcFibonacci(n - 1) + CalcFibonacci(n - 2));

        return m_fibonacciMemorization[n];
    }
}
