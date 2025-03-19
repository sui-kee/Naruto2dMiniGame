using UnityEngine;

public class SnakeBody : MonoBehaviour
{
    public float punchForce = 7f;
    public float punchUpWardPower = 1.2f;
    public float punchRightSidePower = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 punchDirection = new Vector2(punchRightSidePower, punchUpWardPower).normalized; // Right and slightly upward
                rb.AddForce(punchDirection * punchForce, ForceMode2D.Impulse);
            }
        }
    }
}
