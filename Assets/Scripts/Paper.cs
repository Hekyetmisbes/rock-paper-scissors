using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : MonoBehaviour
{
    [SerializeField]
    GameObject scissors;

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

    /*
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Scissors"))
        {
            Debug.Log("Paper Girdi.");
            Destroy(gameObject);
            Instantiate(scissors, other.transform.position, other.transform.rotation);
        }
        if (other.CompareTag("Border"))
        {
            const float MinImpulseForce = 3f;
            const float MaxImpulseForce = 5f;
            float angle = Random.Range(0, 2 * Mathf.PI);
            Vector2 direction = new Vector2(Mathf.Cos(angle - 90), Mathf.Sin(angle - 90));
            float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
            GetComponent<Rigidbody2D>().AddForce(direction * magnitude, ForceMode2D.Impulse);
        }
    }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Scissors"))
        {
            Debug.Log("Scissors Girdi.");
            Destroy(gameObject);
            Instantiate(scissors, collision.transform.position, collision.transform.rotation);
        }
    }
}
