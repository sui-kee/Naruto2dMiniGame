using UnityEngine;

public class Itachi : MonoBehaviour
{
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator animator;
    private float horizontal;
    public bool isFacingRight = true;
    public float speed = 4f;
    public float jump_power = 5f;
    public string currentAnimation = "ItachiIdle";
    public string comingAnimation = "";
    public bool isAttacking = false;
    public bool isHurt = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        Application.targetFrameRate = 60; // Lock to 60 FPS
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x,jump_power);
        }
       
        PlayerAnimatorController();
        PlayerMovementDetector();
        Flip();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(speed * horizontal, rb.linearVelocity.y);
    }

    public void PlayerMovementDetector()
    {
        if (horizontal != 0 && !isAttacking && IsGrounded() && !isHurt)
        {
            comingAnimation = "ItachiRun";
        }
        if (horizontal == 0 && !isAttacking && IsGrounded() && !isHurt)
        {
            comingAnimation = "ItachiIdle";
        }
        if (!isAttacking && !IsGrounded() && rb.linearVelocity.y > 0 && !isHurt)
        {
            comingAnimation = "ItachiJump";
        }
        if (!isAttacking && !IsGrounded() && rb.linearVelocity.y < 0 && !isHurt)
        {
            comingAnimation = "ItachiFall";
        }
    }
    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.3f, groundLayer);
    }
    private void Flip()
    {
        if(isFacingRight && horizontal<0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            transform.Rotate(0f, 180f, 0f);
        }
    }

    private void ChangeAnimation(string animation, float crossFade=0.2f)
    {
        if(currentAnimation != animation)
        {
            currentAnimation = animation;
            animator.CrossFade(animation, crossFade);
        }
    }

    private void PlayerAnimatorController()
    {
        switch (comingAnimation)
        {
            case "ItachiKunai":
                ChangeAnimation(comingAnimation);
                break;
            case "ItachiFireBall":
                ChangeAnimation(comingAnimation);
                break;
            case "ItachiJump":
                ChangeAnimation(comingAnimation);
                break;
            case "ItachiFall":
                ChangeAnimation(comingAnimation);
                break;
            case "ItachiRun":
                ChangeAnimation(comingAnimation);
                break;
            case "ItachiIdle":
                ChangeAnimation(comingAnimation);
                break;
        }
    }
}
