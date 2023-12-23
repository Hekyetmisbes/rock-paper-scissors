using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
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

    
    private int rockCount = 0;
    private int paperCount = 0;
    private int scissorsCount = 0;

    
    public int GetScissorsCount()
    {
        return scissorsCount;
    }
    public void SetScissorsCount(int value)
    {
        scissorsCount = value;
    }
    public int GetRockCount()
    {
        return rockCount;
    }
    public void SetRockCount(int value)
    {
        rockCount = value;
    }
    public int GetPaperCount()
    {
        return paperCount;
    }
    public void SetPaperCount(int value)
    {
        paperCount = value;
    }

    /*public int RockCount
    {
        get
        {
            return rockCount;
        }
        set
        {
            rockCount = value;
        }
    }

    public int PaperCount
    {
        get
        {
            return paperCount;
        }
        set
        {
            paperCount = value;
        }
    }*/

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
        else
        {
            if (scissorsCount == 20)
            {
                Debug.Log("Kaya");
            }
            if (rockCount == 20)
            {
                Debug.Log("Paper");
            }
            if (paperCount == 20)
            {
                Debug.Log("Makas");
            }
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
            Debug.Log("Rock Count: " + rockCount);
            prefabCount++;
            rockCount++;
        }
        else if (spriteNumber == 1)
        {
            prefabs = Instantiate<GameObject>(prefabPaper,
                worldLocation, Quaternion.identity); ;
            Debug.Log("Paper Count: " + paperCount);
            prefabCount++;
            paperCount++;
        }
        else
        {
            prefabs = Instantiate<GameObject>(prefabScissors,
                worldLocation, Quaternion.identity); ;
            Debug.Log("Scissors Count: " + scissorsCount);
            prefabCount++;
            scissorsCount++;
        }
    }
}
