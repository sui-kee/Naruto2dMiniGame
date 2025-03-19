using System.Collections;
using UnityEngine;

public class SnakeSword : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    public float speed = 6f;
    public float rotation_speed = 100f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.linearVelocity = transform.right * speed;
        StartCoroutine(SnakeBehaviour());
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(0f, 0f, -rotation_speed * Time.deltaTime);

    }

    private IEnumerator SnakeBehaviour()
    {
        yield return new WaitForSeconds(0.25f);
        animator.CrossFade("SnakeSwordE", 0.1f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        Destroy(gameObject);

    }
}
