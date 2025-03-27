using UnityEngine;

public class ItachiRunBody : MonoBehaviour
{
    ItachiBelowHurt itachiBelowHurt;
    Itachi itachi;
    AudioManager audioManager;
    [SerializeField] private float hitThurst = 2f;// the thurst force when the enemy's weapon hit

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        itachi = GameObject.FindGameObjectWithTag("Player").GetComponent<Itachi>();
        itachiBelowHurt = GameObject.FindGameObjectWithTag("Player").GetComponent<ItachiBelowHurt>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.ToString().ToLower().Contains("belowd"))
        {
            Debug.Log(collision.gameObject.name);
            if (!itachi.isHurt)
            {
                audioManager.PlaySFX(audioManager.ItachiHurt);
                itachiBelowHurt.isHurtFromBelow = true;
                itachi.isHurt = true;
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.ToString().ToLower().Contains("belowd"))
        {
            Debug.Log(collision.gameObject.name);
            if (!itachi.isHurt)
            {
                audioManager.PlaySFX(audioManager.ItachiHurt);
                itachi.rb.AddForce(transform.right * hitThurst);
                itachiBelowHurt.isHurtFromBelow = true;
                itachi.isHurt = true;
            }

        }
    }
}