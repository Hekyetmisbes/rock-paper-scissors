using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PrefabSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject prefabRock;
    [SerializeField]
    GameObject prefabPaper;
    [SerializeField]
    GameObject prefabScissors;

    [SerializeField]
    TextMeshProUGUI winText;

    [SerializeField]
    Button restartButton;

    const float MinSpawnDelay = 0;
    const float MaxSpawnDelay = 0.8f;
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
        Time.timeScale = 1f;
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
        CheckWinner();
    }

    void CheckWinner()
    {
        int rockCount = 0;
        int paperCount = 0;
        int scissorsCount = 0;

        GameObject[] rockPrefabs = GameObject.FindGameObjectsWithTag("Rock");
        GameObject[] paperPrefabs = GameObject.FindGameObjectsWithTag("Paper");
        GameObject[] scissorsPrefabs = GameObject.FindGameObjectsWithTag("Scissors");

        // Þimdi bu dizileri birleþtirin
        GameObject[] allPrefabs = rockPrefabs.Concat(paperPrefabs).Concat(scissorsPrefabs).ToArray();

        foreach (GameObject prefab in allPrefabs)
        {
            if (prefab.CompareTag("Rock"))
            {
                rockCount++;
            }
            else if (prefab.CompareTag("Paper"))
            {
                paperCount++;
            }
            else if (prefab.CompareTag("Scissors"))
            {
                scissorsCount++;
            }
        }

        // Kazananý belirle
        if (rockCount + scissorsCount == 20)
        {
            Time.timeScale = 0f;
            restartButton.gameObject.SetActive(true);
            winText.text = "Rock win!";
        }
        else if (paperCount + rockCount == 20)
        {
            Time.timeScale = 0f;
            restartButton.gameObject.SetActive(true);
            winText.text = "Paper win!";
        }
        else if (scissorsCount + paperCount == 20)
        {
            Time.timeScale = 0f;
            restartButton.gameObject.SetActive(true);
            winText.text = "Scissors win!";
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
