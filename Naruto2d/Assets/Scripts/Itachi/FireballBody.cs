using UnityEngine;

public class FireballBody : MonoBehaviour
{
    [SerializeField] private Fireball Fireball;
    [SerializeField] private GameObject Fire_ball_body;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Wall"))
        {
            Fireball.hitSomething = true;
            Fireball.burningPos = collision.gameObject.transform.position;
            Fireball.BurningInitiator();
            Destroy(gameObject);

        }
        else
        {
            Destroy(Fire_ball_body);    
        }
    }
}
