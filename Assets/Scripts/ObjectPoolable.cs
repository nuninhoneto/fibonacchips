using UnityEngine;
using UnityEngine.Events;

public class ObjectPoolable : MonoBehaviour
{
	public float LifeTime = 0f;
	
	public UnityEvent OnEnableEvent;
	public UnityEvent OnDestroyEvent;

	public void Destroy()
	{
		gameObject.SetActive(false);

		AppData.Instance.DestroyGameObject();

		OnDestroyEvent?.Invoke();
	}

	void OnEnable()
	{
		if (LifeTime > 0f)
		{
			Invoke("Destroy", LifeTime);
		}

		OnEnableEvent?.Invoke();
	}

	void OnDisable()
	{
		CancelInvoke();
	}
}
