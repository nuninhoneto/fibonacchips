using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnBehaviour
{
	public delegate GameObject CreateGameObject();

    Spawner m_ownerSpawner;

	protected Spawner Owner
	{
		get { return m_ownerSpawner; }
	}

	public SpawnBehaviour(Spawner ownerSpawner)
	{ 
		m_ownerSpawner = ownerSpawner;
	}

	public abstract void Spawn(CreateGameObject createGameObjectHandler);
}
