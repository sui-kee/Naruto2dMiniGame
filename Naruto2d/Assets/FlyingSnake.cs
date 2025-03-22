using System.Collections;
using UnityEngine;

public class FlyingSnake : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    Orochimaru oro;
    Transform target;
    public float speed = 7f;
    public Vector2 targetDirection;
    public bool isFacingRight = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        oro = GameObject.FindGameObjectWithTag("Orochimaru").GetComponent<Orochimaru>();
        target = GameObject.FindGameObjectWithTag("Player").gameObject.transform;
        Vector2 direction = (target.position - transform.position).normalized;
        //if (!oro.isFacingRight)  // Meaning Orochimaru is flipped
        //{
        //    transform.Rotate(0f, 180f, 0f);
        //}

        // Rotate to face player
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        targetDirection = direction;
        rb.freezeRotation = true;// there is a bug when the oro face left and shoot the snake the snake keep spinning 
        StartCoroutine(FlyingSnakeBehaviour());
    }

    // Update is called once per frame
    void Update()
    {
        // Move towards player
        rb.linearVelocity = targetDirection * speed;
    }

    private IEnumerator FlyingSnakeBehaviour()
    {
        yield return new WaitForSeconds(0.40f);
        animator.CrossFade("FSnakeE",0.1f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Orochimaru"))
        {
            Destroy(gameObject);
        }
    }
}
