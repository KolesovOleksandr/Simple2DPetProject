using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] EnemySpawnEntry[] spawnEntries;
    [SerializeField] float minRadius = 5f;
    [SerializeField] float maxRadius = 20f;
    [SerializeField] bool spawning = true;

    [SerializeField] Transform player;

    void Start()
    {
        for (int i = 0; i < spawnEntries.Length; i++)
        {
            StartCoroutine(Spawn(spawnEntries[i]));
        }
    }

    IEnumerator Spawn(EnemySpawnEntry entry)
    {
        while (spawning)
        {
            yield return new WaitForSeconds(entry.spawnRate);

            Vector2 dir = Random.insideUnitCircle.normalized;
            float dist = Random.Range(minRadius, maxRadius);
            Vector3 spawnPos = player.position + (Vector3)(dir * dist);
            Debug.Log(player.position);

            Instantiate(entry.enemy, spawnPos, Quaternion.identity);
        }
    }
}

[System.Serializable]
public class EnemySpawnEntry
{
    public Enemy enemy;
    public float spawnRate;
}