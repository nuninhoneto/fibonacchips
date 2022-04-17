using UnityEngine;

public class DefaultSpawnBehaviour : SpawnBehaviour
{
    public DefaultSpawnBehaviour(Spawner ownerSpawner) : base(ownerSpawner) { }

    public override void Spawn(CreateGameObject createGameObjectHandler)
    {
        GameObject gObj = createGameObjectHandler.Invoke();

        if (gObj != null)
        {
            gObj.transform.SetParent(null);
            gObj.transform.position = Owner.SpawnPosition;
            gObj.SetActive(true);
        }
    }
}
