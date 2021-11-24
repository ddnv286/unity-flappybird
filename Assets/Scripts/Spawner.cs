using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawnRate = 1f;
    public float minHeight = -1f;
    public float maxHeight = 2f;

    public void OnEnable ()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    public void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn ()
    {
        // spawning pipes using previously made prefabs
        // 3rd param set to identity since we don't want any of the pipes to be rotated
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);
        // then set the x position to be random
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }
}
