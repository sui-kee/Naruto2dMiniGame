using UnityEngine;

public class ItachiRunBody : MonoBehaviour
{
    ItachiBelowHurt itachiBelowHurt;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
            itachiBelowHurt.isHurtFromBelow = true;
        }

    }
}
