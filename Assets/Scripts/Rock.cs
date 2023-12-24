using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField]
    GameObject paper;


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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paper"))
        {
            Destroy(gameObject);
            Instantiate(paper, collision.transform.position, collision.transform.rotation);
        }
    }
}
