using UnityEngine;

public class WaterDragon : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    Transform target;
    public float speed = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb.linearVelocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = new Vector3(target.position.x, target.position.y);
        Vector3 direction = (targetPos - transform.position).normalized;

        // Rotate to face player
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        //rb.position = new Vector2(transform.position.x+speed *Time.deltaTime,transform.position.y);
        rb.linearVelocity = speed * direction;
        //Vector3 newPosition = Vector3.MoveTowards(transform.position, target.position,Time.deltaTime);
        //rb.MovePosition(newPosition);
        //rb.linearVelocity = new Vector2(rb.linearVelocity.x*speed,rb.linearVelocity.y);
    }
}
