using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Scissors : MonoBehaviour
{
    [SerializeField]
    GameObject rock;

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
        if (collision.gameObject.CompareTag("Rock"))
        {
            Debug.Log("Scissors Girdi.");
            Destroy(gameObject);
            Instantiate(rock, collision.transform.position, collision.transform.rotation);
            spawner.SetScissorsCount(spawner.GetScissorsCount() - 1);
            Debug.Log("Scissors Count in Scissors: " + spawner.GetScissorsCount());
            spawner.SetRockCount(spawner.GetRockCount() + 1);
            Debug.Log("Rock Count in Scissors: " + spawner.GetRockCount());
        }
    }
}
