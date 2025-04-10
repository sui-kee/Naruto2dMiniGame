using System.Collections;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    public float speed = 6f;
    public bool hitSomething = false;
    public float destroyTime = 1f;
    public bool canFly = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(FireBallBehaviour());
    }

    // Update is called once per frame
    void Update()
    {
        if (canFly)
        {

            rb.linearVelocity = transform.right * speed;
        }
    }

    public void DestroyFireball() 
    {
        Destroy(gameObject);
    }

    public IEnumerator FireBallBehaviour()
    {
        yield return new WaitForSeconds(0.20f);
        canFly = true;
        animator.CrossFade("FlameE", 0f);
    }
    
}
