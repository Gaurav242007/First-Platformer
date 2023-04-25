using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject blockPrefab;

    public float timeBetweenWaves = 1f;
    private float timeToSpawn = 2f;
    void Update()
    {
        // Amount of time passed by since we started the game
        if (Time.time >= timeToSpawn)
        {
            SpawnBlocks();
            timeToSpawn = Time.time + timeBetweenWaves;

        }
    }

    void SpawnBlocks()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (randomIndex != i)
            {
                //  Quaternion.identity not to rotate the created mesh
                Instantiate(blockPrefab, spawnPoints[i].position, Quaternion.identity);
            }
        }
    }
}
