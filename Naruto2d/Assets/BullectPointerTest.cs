using UnityEngine;

public class BulletPointerTest : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    PointerTest pointer;
    public float speed = 7f;
    public Vector2 targetDirection;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pointer = GameObject.FindGameObjectWithTag("TestGun").GetComponent<PointerTest>();
        rb.rotation = pointer.angle;
        targetDirection = pointer.direction;
    }

    // Update is called once per frame
    void Update()
    {
        // Move towards player
        rb.linearVelocity = targetDirection * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
