using UnityEngine;

public class Anbu : MonoBehaviour
{
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    public float Ground_CheckPoint_radius = 0.2f;
    Itachi itachi;
    AnbuBody anbuBody;
    public float lives = 3f;
    public float distance;
    public bool isFacingRight = true;
    public bool isHurt = false;
    public bool isAttacking = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anbuBody = GameObject.FindGameObjectWithTag("AnbuEnemy").GetComponentInChildren<AnbuBody>();
        itachi = GameObject.FindGameObjectWithTag("Player").GetComponent<Itachi>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = new Vector2(0f, rb.linearVelocity.y);
        distance = Vector2.Distance(itachi.transform.position,transform.position);
        Flip();
        //Debug.Log($" P vs Anbu distance: {distance} child- {anbuBody.player_anbu_distance}");
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, Ground_CheckPoint_radius, groundLayer);
    }

    public void Flip()
    {
        if (isFacingRight && rb.position.x > itachi.rb.position.x && !isHurt && !isAttacking)
        {
            isFacingRight = !isFacingRight;
            transform.Rotate(0f, 180f, 0f);
        }
        else if (!isFacingRight && rb.position.x < itachi.rb.position.x && !isHurt && !isAttacking)
        {
            isFacingRight = !isFacingRight;
            transform.Rotate(0f, 180f, 0f);
        }
    }
}
