using System.Collections;
using UnityEngine;

public class Kunai : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    ItachiKick specialKick;
    public float speed = 6f;
    public float rotation_speed = 100f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        specialKick = GameObject.FindGameObjectWithTag("Player").GetComponent<ItachiKick>();
        rb.linearVelocity = transform.right * speed;
        StartCoroutine(KunaiBehaviour());
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(0f,0f,-rotation_speed*Time.deltaTime);

    }

    private IEnumerator KunaiBehaviour()
    {
        yield return new WaitForSeconds(0.25f);
        animator.CrossFade("KunaiSpeed",0.1f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("OrochimaruBody"))
        {
            specialKick.targetIsLock = true;
            Destroy(gameObject);
        }
        if (!collision.CompareTag("OroObjectDetector"))
        {
            Destroy(gameObject);
        }   
    }
}
