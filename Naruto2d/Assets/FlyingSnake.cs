using System.Collections;
using UnityEngine;

public class FlyingSnake : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    OroShootSnakeUp shooter;
    Orochimaru oro;
    Transform target;
    public float speed = 7f;
    public Vector2 targetDirection;
    public float rotation;
    public bool isFacingRight = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shooter = GameObject.FindGameObjectWithTag("Orochimaru").GetComponent<OroShootSnakeUp>();
        oro = GameObject.FindGameObjectWithTag("Orochimaru").GetComponent<Orochimaru>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        targetDirection = shooter.direction;
        rotation = shooter.angle;
        if(!oro.isFacingRight)
        {
            transform.rotation = Quaternion.Euler(0f,0f,shooter.angle); 
        }
        else
        {
            rb.rotation = shooter.angle;
        }
        StartCoroutine(FlyingSnakeBehaviour());
    }

    // Update is called once per frame
    void Update()
    {
        //Vector2 direction = (target.position - transform.position).normalized;
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.linearVelocity = targetDirection * speed;
    }

    private IEnumerator FlyingSnakeBehaviour()
    {
        yield return new WaitForSeconds(0.40f);
        animator.CrossFade("FSnakeE",0.1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }

    }
}
