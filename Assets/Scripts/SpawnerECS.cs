using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Rendering;
using Unity.Mathematics;

public class SpawnerECS : MonoBehaviour
{
    EntityManager m_entityManager;
    [SerializeField] private Mesh enemyMesh;
    [SerializeField] private Material[] enemyMaterial;

    Entity test;

    void Start()
    {
        m_entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

        test = Create();
        // m_entityManager.SetComponentData(Create(), new Rotation { Value = quaternion.EulerXYZ(new float3(-90f, 0f, 0f)) });
    }

    void Update()
    {
        m_entityManager.SetComponentData(test, new Translation { Value = new Vector3(Time.time, 0f, 0f) });
    }

    Entity Create()
    {
        EntityArchetype archetype = m_entityManager.CreateArchetype(
         typeof(Translation),
         typeof(Rotation),
         typeof(LocalToWorld)
         );

        EntityArchetype archetype2 = m_entityManager.CreateArchetype(
         typeof(Parent),
         typeof(Translation),
         typeof(RenderMesh),
         typeof(RenderBounds),
         typeof(LocalToWorld),
         typeof(LocalToParent)
         );

        Entity parent = m_entityManager.CreateEntity(archetype);

        Entity child = m_entityManager.CreateEntity(archetype2);
        Entity child2 = m_entityManager.CreateEntity(archetype2);

        m_entityManager.AddComponentData(child, new Parent { Value = parent });
        m_entityManager.AddComponentData(child2, new Parent { Value = parent });

        m_entityManager.AddSharedComponentData(child, new RenderMesh
        {
            mesh = enemyMesh,
            material = enemyMaterial[0],
            subMesh = 0
        });

        m_entityManager.AddSharedComponentData(child2, new RenderMesh
        {
            mesh = enemyMesh,
            material = enemyMaterial[1],
            subMesh = 1
        });

        DynamicBuffer<LinkedEntityGroup> linkedEntities = m_entityManager.AddBuffer<LinkedEntityGroup>(parent);
        linkedEntities.Add(new LinkedEntityGroup { Value = parent });
        linkedEntities.Add(new LinkedEntityGroup { Value = child });
        linkedEntities.Add(new LinkedEntityGroup { Value = child2 });

        return parent;
    }
}
