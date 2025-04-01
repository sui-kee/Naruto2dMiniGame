using System.Collections;
using UnityEngine;

public class Kunai : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    ItachiKick specialKick;
    //GameObject target=null;
    public float speed = 6f;
    public float rotation_speed = 100f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        
        specialKick = GameObject.FindGameObjectWithTag("ItachiKick").GetComponent<ItachiKick>();
    }
    void Start()
    {
        rb.linearVelocity = transform.right * speed;
        StartCoroutine(KunaiBehaviour());
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(0f,0f,-rotation_speed*Time.deltaTime);
        //if(target != null)
        //{
        //    transform.position = new Vector2(target.transform.position.x, target.transform.position.y + 2);
        //}

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

            specialKick.target = collision.gameObject;
            Destroy(gameObject);
        }
        if (!collision.CompareTag("OroObjectDetector"))
        {
            Destroy(gameObject);
        }   
    }

    //public void DestroyKunai()
    //{
    //    Destroy(gameObject);
    //}
}
