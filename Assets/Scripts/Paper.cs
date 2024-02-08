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
        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
        GetComponent<Rigidbody2D>().AddForce(direction * magnitude, ForceMode2D.Impulse);
    }

    // Check for collision with scissors
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Scissors"))
        {
            Destroy(gameObject);
            Instantiate(scissors, collision.transform.position, collision.transform.rotation);
        }
    }
}
