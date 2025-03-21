using System.Collections;
using UnityEngine;

public class FlyingSnake : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    OroShootSnakeUp pointer;
    public float speed = 7f;
    public Vector2 targetDirection;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pointer = GameObject.FindGameObjectWithTag("Orochimaru").GetComponent<OroShootSnakeUp>();
        rb.rotation = pointer.angle;
        targetDirection = pointer.direction;
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
        yield return new WaitForSeconds(0.20f);
        animator.CrossFade("FSnakeE",0.1f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
