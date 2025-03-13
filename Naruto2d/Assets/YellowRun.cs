using UnityEngine;

public class YellowRun : StateMachineBehaviour
{
    YellowNinja yellowNinja;
    YellowKunaiAttack yellow_shoot;
    Rigidbody2D rb;
    Transform player;
    public float sword_range = 1f;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        yellow_shoot = animator.GetComponent<YellowKunaiAttack>();
        yellowNinja = animator.GetComponent<YellowNinja>();
        rb = animator.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float distance = Vector2.Distance(player.position, rb.transform.position);
        //auto following player
        if(distance>= sword_range)
        {
            yellowNinja.FollowPlayer();
        }
        // slicing attack
        if (distance <= sword_range)
        {
            animator.SetTrigger("SwordAttack");
        }
        // follow or not activator
        if (!yellowNinja.isPlayerOnRange)
        {
            animator.ResetTrigger("PlayerDetected");
            animator.SetTrigger("Activate");
        }
        // hurt mode
        if (yellowNinja.isHurt)
        {
            yellowNinja.Stop();
            animator.SetTrigger("Hurt");
        }
        // shooting attack
        if(yellowNinja.isPlayerOnRange && yellow_shoot.canShoot)
        {
            animator.SetTrigger("Shoot");
        }
        
        yellowNinja.Flip();
        //Follow player
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        yellowNinja.Stop();
        animator.ResetTrigger("SwordAttack");
        animator.ResetTrigger("Hurt");
        animator.ResetTrigger("Shoot");
        yellowNinja.isHurt = false;
    }

}
