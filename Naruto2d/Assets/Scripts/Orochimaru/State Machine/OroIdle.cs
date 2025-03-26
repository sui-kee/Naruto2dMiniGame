using UnityEngine;

public class OroIdle : StateMachineBehaviour
{
    Orochimaru oro;
    OroPlayerDetector detector;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        detector = animator.GetComponent< OroPlayerDetector>();
        oro = animator.GetComponent< Orochimaru>();
        oro.normalHurt = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //oro.Stop();
        if (oro.aboveHurt)
        {
            animator.SetTrigger("AboveHurt");
        }
        if (detector.PlayerIsOnSight())
        {
            animator.SetTrigger("DetectP");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Idle");
        animator.ResetTrigger("AboveHurt");
    }

}
