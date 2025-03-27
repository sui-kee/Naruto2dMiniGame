using UnityEngine;

public class Orochimaru : MonoBehaviour
{
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] private Itachi itachi;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private OroPlayerDetector detectPlayer;
    OroSummonSnake summonSnake;
    OroShootSnakeUp shootSnakeUp;
    public bool isHurt = false;
    public float runningSpeed = 2f;
    public bool belowHurt = false;
    public bool aboveHurt = false;
    public bool horizontalHurt = false;
    public bool normalHurt = false;
    public bool isAttacking = false;
    public bool isFacingRight = true;
    public bool isIdle = true;
    public bool isDying = false;
    public bool oro_isGrounded = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        summonSnake = gameObject.GetComponent< OroSummonSnake>();
        shootSnakeUp = gameObject.GetComponent< OroShootSnakeUp>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGrounded())
        {
            oro_isGrounded = true;
        }
        else if (!IsGrounded())
        {
            oro_isGrounded = false;
        }
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.3f, groundLayer);
    }

    public void ChangeDirection()
    {
        if (isFacingRight && rb.position.x > itachi.rb.position.x && !isHurt && !isAttacking )
        {
            Flip();
        }
        else if (!isFacingRight && rb.position.x < itachi.rb.position.x && !isHurt && !isAttacking)
        {
            Flip();
        }
    }

    public void MoveToPlayer()

    {
        if (detectPlayer.PlayerIsOnSight() && !isHurt && !isAttacking && detectPlayer.ShouldChase())//
        {
            float direction = isFacingRight ? 1f : -1f;
            rb.linearVelocity = new Vector2(direction * runningSpeed, rb.linearVelocity.y);
        }

    }

    public void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    public void Stop()
    {
        rb.linearVelocity = Vector2.zero;
    }

    public void IdleModeReset()//(for unessceroy bug and conditions) when it goes back to the idle mode all the bool and condition should go back to the idle mode
    {
        isHurt = false;
        belowHurt = false;
        aboveHurt = false;
        horizontalHurt = false;
        isAttacking = false;
        isIdle = true;
        isDying = false;
        //summonSnake.canSummon = true;
        shootSnakeUp.canShoot = true;
        normalHurt = false;
}
}
