using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : MonoBehaviour
{
    [SerializeField]
    GameObject scissors;

    PrefabSpawner spawner;

    // Start is called before the first frame update
    void Start()
    {
        const float MinImpulseForce = 3f;
        const float MaxImpulseForce = 5f;
        float angle = Random.Range(0, 2 * Mathf.PI);
        Vector2 direction = new Vector2(
            Mathf.Cos(angle), Mathf.Sin(angle));
        float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
        GetComponent<Rigidbody2D>().AddForce(direction * magnitude, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Scissors"))
        {
            Debug.Log("Paper Girdi.");
            Destroy(gameObject);
            Instantiate(scissors, collision.transform.position, collision.transform.rotation);
            spawner.SetPaperCount(spawner.GetPaperCount() - 1);
            Debug.Log("Paper Count in Paper: " + spawner.GetPaperCount());
            spawner.SetScissorsCount(spawner.GetScissorsCount() + 1);
            Debug.Log("Scissors Count in Paper: " + spawner.GetScissorsCount());
        }
    }
}
