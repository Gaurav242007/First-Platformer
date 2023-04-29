using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject enemyPrefab;

    public float timeBetweenWaves = 4f;
    public float timeToSpawn = 8f;
    public float difficultyLevel = 0.04f;
    // maximum the above the value the level will become more quickly harder

    public float MaximumDifficulty = 0.8f;
    // minimum the above higher the maximumdifficulty
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
            if (randomIndex == i)
            {
                //  Quaternion.identity not to rotate the created mesh
                Instantiate(enemyPrefab, spawnPoints[i].position, Quaternion.identity);
            }
        }
        if(timeBetweenWaves >= MaximumDifficulty)
        {
            timeBetweenWaves -= difficultyLevel;
        }
    }
}
