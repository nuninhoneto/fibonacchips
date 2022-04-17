using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnBecameInvisible : MonoBehaviour
{
    void OnBecameInvisible()
    {
        if (TryGetComponent(out ObjectPoolable objectPoolable))
        {
            objectPoolable.Destroy();
        }
    }
}
