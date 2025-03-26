using UnityEngine;

public class ItachiRunBody : MonoBehaviour
{
    ItachiBelowHurt itachiBelowHurt;
    Itachi itachi;
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
                itachiBelowHurt.isHurtFromBelow = true;
                itachi.isHurt = true;
            }

        }
    }
}