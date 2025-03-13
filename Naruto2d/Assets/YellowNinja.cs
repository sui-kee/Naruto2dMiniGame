using Unity.VisualScripting;
using UnityEngine;

public class YellowNinja : MonoBehaviour
{
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] private Itachi player;
    public float activateRange = 4.5f;
    public float dectectRange = 10f;
    public float run_speed = 3f;
    public bool isHurt = false;
    public bool isShooting = false;
    public bool isPiercing = false;
    public bool isFacingRight = true;
    public bool isActivate = false;
    public bool isPlayerOnRange = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DetectPlayer();
        Activate();
    }

    public void Flip()
    {
        if (isFacingRight && rb.position.x > player.rb.position.x)
        {
            isFacingRight = !isFacingRight;
            transform.Rotate(0f, 180f, 0f);
        }
        else if (!isFacingRight && rb.position.x < player.rb.position.x)
        {
            isFacingRight = !isFacingRight;
            transform.Rotate(0f, 180f, 0f);
        }
    }

    // activator
    public void Activate()
    {
        float distance = Vector2.Distance(player.rb.position, rb.position);
        if (distance < activateRange)
        {
            isActivate = true;
        }
    }
    // follow player
    public void FollowPlayer()
    {
        float direction = isFacingRight ? 1f : -1f;
        rb.linearVelocity = new Vector2(direction * run_speed, rb.linearVelocity.y);
    }
    // stop player 
    public void Stop()
    {
        rb.linearVelocity = Vector2.zero;
    }
    // attack range
    // player is on sight
    public void DetectPlayer()
    {
        float distance = Vector2.Distance(player.rb.position, rb.position);
        if (distance < dectectRange && player.rb.position.y<-1.54)
        {
            isPlayerOnRange = true;
        }
        else
        {
            isPlayerOnRange = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FireBall") || collision.CompareTag("PlayerKunai"))
        {
            isHurt = true;
        }
    }
}
