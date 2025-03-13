using System.Collections;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    public float speed = 6f;
    public bool hitSomething = false;   
    public Vector2 burningPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(!hitSomething)
        {
            rb.linearVelocity = transform.right * speed;

        }
    }

    public IEnumerator FireballBehavior()
    {
        rb.linearVelocity = new Vector2(0f, 0f);
        transform.localScale *= 2f;
        rb.transform.position = burningPos;
        animator.CrossFade("FireBallBurn", 0.1f);
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
        Debug.Log("Destroy should work:");
    }

    public void BurningInitiator()
    {
        hitSomething = true;
        StartCoroutine(FireballBehavior());
    }
    
}
