using UnityEngine;

public class Itachi : MonoBehaviour
{
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject idleBody;
    [SerializeField] private GameObject runBody;
    [SerializeField] private ItachiKick kickSkill;
    [SerializeField] private float Ground_CheckPoint_radius = 0.3f;
    private float horizontal;
    public bool isFacingRight = true;
    public float speed = 4f;
    public float jump_power = 5f;
    public string currentAnimation = "ItachiIdle";
    public string comingAnimation = "";
    public bool SusanooMode = false;
    public bool isAttacking = false;
    public bool isHurt = false;
    public bool isDying = false;// this dying bool should be TRUE when ever the player get knock up or knock down and also for death mode
    public bool isSpecialKicking = false;// special bool for controlling player linear velocity for kicking skill
    public float susanooScale = 3f;
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
        if (Input.GetKeyDown(KeyCode.T) && !SusanooMode)
        {
            SusanooMode = true;
            comingAnimation = "ItachiSSModeIdle";
            transform.localScale *= susanooScale;
        }
        if (!SusanooMode)
        {
            if (Input.GetButtonDown("Jump") && IsGrounded() && !isHurt)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jump_power);
            }
           
            PlayerMovementDetector();
        }
        PlayerAnimatorController();
        Flip();
    }

    private void FixedUpdate()
    {
        BodyController();
        if(!isDying)
        {

            if(isSpecialKicking)
            {
                rb.linearVelocity = new Vector2(0f, 0f);
            }
            if (!isAttacking && !isHurt)
            {
                rb.linearVelocity = new Vector2(speed * horizontal, rb.linearVelocity.y);
            }else if (currentAnimation == "ItachiBelowDE" && !IsGrounded())// when itachi is kock down and falling
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x,rb.linearVelocity.y);
            }
            else
            {
                rb.linearVelocity = new Vector2(0f,rb.linearVelocity.y);// 0f is used to stop player horizontally so it won't move horizontally when the skill is used
            }
        }
        
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
        return Physics2D.OverlapCircle(groundCheck.position, Ground_CheckPoint_radius, groundLayer);
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

    private void BodyController()
    {
        if (isSpecialKicking)
        {
            idleBody.SetActive(false);
            runBody.SetActive(false);   
        }
        if (isDying && IsGrounded())
        {
            rb.linearVelocity = new Vector2(0f, 0f);
            rb.gravityScale = 0f;
            idleBody.SetActive(false);
            runBody.SetActive(false);
        }
        if (currentAnimation == "ItachiRun")
        {
            idleBody.SetActive(false);
            runBody.SetActive(true);
        }
        else if(!kickSkill.isKicking && !isDying)
        {
            rb.gravityScale = 1f;
            idleBody.SetActive(true);
        }
    }

    private void PlayerAnimatorController()
    {
        switch (comingAnimation)
        {
            case "ItachiVanish":
                ChangeAnimation(comingAnimation);
                break;
            case "ItachiSSModeIdle":
                ChangeAnimation(comingAnimation);
                break;
            case "ItachiDie":
                ChangeAnimation(comingAnimation);
                break;
            case "ItachiRevive":
                ChangeAnimation(comingAnimation);
                break;
            case "ItachiBelowDS":// when below incoming damage is hit
                ChangeAnimation(comingAnimation);
                break;
            case "ItachBelowDE":// when itachi below incoming damage end
                ChangeAnimation(comingAnimation);
                break;
            case "ItachiBlackFlame":
                ChangeAnimation(comingAnimation);
                break;
            case "ItachiSlice":
                ChangeAnimation(comingAnimation);
                break;
            case "ItachiKick":
                ChangeAnimation(comingAnimation);
                break;
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
