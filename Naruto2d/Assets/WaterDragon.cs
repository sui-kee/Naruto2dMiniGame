using UnityEngine;

public class WaterDragon : MonoBehaviour
{
    [SerializeField] private DragonGate dragonGate;
    [SerializeField] private Rigidbody2D rb;
    AnbuWaterJutsu jutsu;
    Anbu anbu;
    public Transform target;
    public float speed = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anbu = GameObject.FindGameObjectWithTag("AnbuEnemy").GetComponent<Anbu>();
        jutsu = GameObject.FindGameObjectWithTag("AnbuEnemy").GetComponentInChildren<AnbuWaterJutsu>();
        target = dragonGate.dragon_target;
        rb.linearVelocity = transform.right * speed;
        if (!anbu.isFacingRight)
        {
            transform.Rotate(180f,0f,0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        target = dragonGate.dragon_target;
        Vector3 targetPos = new Vector3(target.position.x, target.position.y);
        Vector3 direction = (targetPos - transform.position).normalized;

        // Rotate to face player
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        //rb.position = new Vector2(transform.position.x+speed *Time.deltaTime,transform.position.y);
        rb.linearVelocity = speed * direction;
        //Vector3 newPosition = Vector3.MoveTowards(transform.position, target.position,Time.deltaTime);
        //rb.MovePosition(newPosition);
        //rb.linearVelocity = new Vector2(rb.linearVelocity.x*speed,rb.linearVelocity.y);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            jutsu.canSummon = true;
            Destroy(dragonGate.gameObject);
        }
    }
}
