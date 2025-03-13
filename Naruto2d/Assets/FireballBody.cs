using UnityEngine;

public class FireballBody : MonoBehaviour
{
    [SerializeField] Fireball Fireball;
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
        Fireball.hitSomething = true;
        Fireball.burningPos = collision.gameObject.transform.position;
        Fireball.BurningInitiator();
        Destroy(gameObject);
    }
}
