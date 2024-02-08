using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PrefabSpawner : MonoBehaviour
{
    // Define prefabs array and other variables
    [SerializeField]
    GameObject[] prefabsArray = new GameObject[3];
    
    GameObject prefabRock;
    GameObject prefabPaper;
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

            // Change spawn timer duration and restart
            spawnTimer.Duration = Random.Range(MinSpawnDelay, MaxSpawnDelay);
            spawnTimer.Run();
        }
        CheckWinner();
    }

    void CheckWinner()
    {
        // Count the number of each type of prefab
        int rockCount = 0;
        int paperCount = 0;
        int scissorsCount = 0;

        GameObject[] rockPrefabs = GameObject.FindGameObjectsWithTag("Rock");
        GameObject[] paperPrefabs = GameObject.FindGameObjectsWithTag("Paper");
        GameObject[] scissorsPrefabs = GameObject.FindGameObjectsWithTag("Scissors");

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

        // Determine the winner
        if (rockCount + scissorsCount == 20 && paperCount == 0)
        {
            Time.timeScale = 0f;
            restartButton.gameObject.SetActive(true);
            winText.text = "Rock win!";
        }
        else if (paperCount + rockCount == 20 && scissorsCount == 0)
        {
            Time.timeScale = 0f;
            restartButton.gameObject.SetActive(true);
            winText.text = "Paper win!";
        }
        else if (scissorsCount + paperCount == 20 && rockCount == 0)
        {
            Time.timeScale = 0f;
            restartButton.gameObject.SetActive(true);
            winText.text = "Scissors win!";
        }
    }

    void SpawnPrefabs()
    {
        // Generate random location and create rock, paper and scissors
        Vector3 location = new Vector3(Random.Range(minSpawnX, maxSpawnX),
            Random.Range(minSpawnY, maxSpawnY),
            -Camera.main.transform.position.z);
        Vector3 worldLocation = Camera.main.ScreenToWorldPoint(location);

        GameObject prefabs;
        prefabs = Instantiate<GameObject>(prefabsArray[Random.Range(0, 3)],
            worldLocation, Quaternion.identity); ;
        prefabCount++;
    }
}
