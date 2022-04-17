using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    public float MinSpeed = 10f;
    public float MaxSpeed = 15f;
    public Vector3 Direction = Vector3.left;
    public Vector3 BoundsSize = Vector3.zero;

    float m_speed;
    float m_accelerationFactor;

    void OnEnable()
    {
        m_speed = Random.Range(MinSpeed, MaxSpeed);
        m_accelerationFactor = Random.Range(0, 0.5f);
    }

    void Update()
    {
        transform.Translate(Direction.normalized * m_speed * Time.deltaTime, Camera.main.transform);

        if (m_speed <= MaxSpeed)
            m_speed += m_speed * m_accelerationFactor * Time.deltaTime;
        

        if (!IsVisible())
        {
            if (TryGetComponent(out ObjectPoolable objectPoolable))
            {
                objectPoolable.Destroy();
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    bool IsVisible()
    {
        return GeometryUtility.TestPlanesAABB(GeometryUtility.CalculateFrustumPlanes(Camera.main), new Bounds(transform.position, BoundsSize));
    }
}
