using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class Kunai : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private CinemachineBrain kunaiCam;
    Itachi itachi;
    ItachiKick specialKick;
    //GameObject target=null;
    public float speed = 6f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        itachi = GameObject.FindGameObjectWithTag("Player").GetComponent<Itachi>();
        specialKick = GameObject.FindGameObjectWithTag("ItachiKick").GetComponent<ItachiKick>();
    }
    void Start()
    {
        rb.linearVelocity = transform.right * speed;
        StartCoroutine(KunaiBehaviour());
        specialKick.target = gameObject;
        specialKick.targetIsEnemy = false;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(0f,0f,-rotation_speed*Time.deltaTime);
        //if(target != null)
        //{
        //    transform.position = new Vector2(target.transform.position.x, target.transform.position.y + 2);
        //}
        //if (Input.GetKey(KeyCode.E))
        //{
        //    kunaiCam.
        //}

    }

    private IEnumerator KunaiBehaviour()
    {
        yield return new WaitForSeconds(0.25f);
        //animator.CrossFade("KunaiSpeed",0.1f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("OrochimaruBody") || collision.CompareTag("AnbuBody"))
        {
            itachi.throwingKunai = false;
            specialKick.targetIsEnemy = true;
            specialKick.target = collision.gameObject;
            Destroy(gameObject);
        }else if (!collision.CompareTag("OroObjectDetector")) 
        {
            itachi.throwingKunai = false;
            //Debug.Log("It also went here");
            specialKick.targetIsEnemy = false;
            Destroy(gameObject);
        }   
    }

    //public void DestroyKunai()
    //{
    //    Destroy(gameObject);
    //}
}
