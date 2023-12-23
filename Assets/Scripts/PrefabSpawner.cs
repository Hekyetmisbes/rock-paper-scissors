using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject prefabRock;
    [SerializeField]
    GameObject prefabPaper;
    [SerializeField]
    GameObject prefabScissors;

    const float MinSpawnDelay = 0;
    const float MaxSpawnDelay = 1;
    Timer spawnTimer;

    const int SpawnBorderSize = 100;
    int minSpawnX;
    int minSpawnY;
    int maxSpawnX;
    int maxSpawnY;

    int prefabCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        minSpawnX = SpawnBorderSize;
        maxSpawnX = Screen.width - SpawnBorderSize;
        minSpawnY = SpawnBorderSize;
        maxSpawnY = Screen.height - SpawnBorderSize;

        spawnTimer = gameObject.AddComponent<Timer>();
        spawnTimer.Duration = Random.Range(MinSpawnDelay, MaxSpawnDelay);
        spawnTimer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer.Finished && prefabCount < 20)
        {
            SpawnPrefabs();

            // change spawn timer duration and restart
            spawnTimer.Duration = Random.Range(MinSpawnDelay, MaxSpawnDelay);
            spawnTimer.Run();
        }
    }

    void SpawnPrefabs()
    {
        // generate random location and create new teddy bear
        Vector3 location = new Vector3(Random.Range(minSpawnX, maxSpawnX),
            Random.Range(minSpawnY, maxSpawnY),
            -Camera.main.transform.position.z);
        Vector3 worldLocation = Camera.main.ScreenToWorldPoint(location);

        GameObject prefabs;
        int spriteNumber = Random.Range(0, 3);
        if (spriteNumber == 0)
        {
            prefabs = Instantiate<GameObject>(prefabRock,
                worldLocation, Quaternion.identity); ;
            prefabCount++;
        }
        else if (spriteNumber == 1)
        {
            prefabs = Instantiate<GameObject>(prefabPaper,
                worldLocation, Quaternion.identity); ;
            prefabCount++;
        }
        else
        {
            prefabs = Instantiate<GameObject>(prefabScissors,
                worldLocation, Quaternion.identity); ;
            prefabCount++;
        }
    }
}
