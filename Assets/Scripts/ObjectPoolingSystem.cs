using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolingSystem : MonoBehaviour
{ 
	public GameObject GameObjectToPool;
	public int InitialSize = 20;
	public bool CanExpand = true;

	List<GameObject> m_pooledGameObjects;

	void Awake()
	{
		Init();
	}

	void Init()
	{
		m_pooledGameObjects = new List<GameObject>();

		if (GameObjectToPool == null)
			return;

		for (int i = 0; i < InitialSize; i++)
		{
			CreateNewGameObject();
		}
	}

	public GameObject RetrieveGameObject()
	{
		if (m_pooledGameObjects == null)
			Init();

		for (int i = 0; i < m_pooledGameObjects.Count; i++)
		{
			if (!m_pooledGameObjects[i].gameObject.activeInHierarchy)
			{
				return m_pooledGameObjects[i];
			}
		}

		if (CanExpand)
		{
			return CreateNewGameObject();
		}

		return null;
	}

	GameObject CreateNewGameObject()
	{
		if (GameObjectToPool == null)
			return null;

		GameObject newGameObject = Instantiate(GameObjectToPool);

		newGameObject.gameObject.SetActive(false);		
		newGameObject.transform.SetParent(gameObject.transform);
		newGameObject.name = GameObjectToPool.name + " (" + m_pooledGameObjects.Count + ")";

		m_pooledGameObjects.Add(newGameObject);

		return newGameObject;
	}
}
