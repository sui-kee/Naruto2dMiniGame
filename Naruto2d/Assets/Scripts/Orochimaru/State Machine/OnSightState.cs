using UnityEngine;

public class OnSightState : StateMachineBehaviour
{
    OroPlayerDetector detector;
    Orochimaru oro;
    Itachi player;
    OroShootSnakeUp shootSnakeUp;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        shootSnakeUp = animator.GetComponent<OroShootSnakeUp>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Itachi>();
        detector = animator.GetComponent<OroPlayerDetector>();
        oro = animator.GetComponent<Orochimaru>();
        oro.isHurt = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        oro.Stop();
        oro.ChangeDirection();
        if (!detector.PlayerIsOnSight())
        {
            animator.SetTrigger("Idle");
        }
        if (player.IsGrounded() && detector.PlayerIsOnSight())
        {
            oro.Stop();
            animator.SetTrigger("HorizontalDetect");
        }
        if(!player.IsGrounded() && shootSnakeUp.canShoot && !oro.isHurt && player.transform.position.y >-1.5f)
        {
            animator.SetTrigger("FSAttack");
        } 
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("DetectP");
        animator.ResetTrigger("FSAttack");
    }
}
