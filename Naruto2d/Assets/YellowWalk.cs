using UnityEngine;

public class YellowWalk : StateMachineBehaviour
{
    YellowNinja yellowNinja;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        yellowNinja = animator.GetComponent<YellowNinja>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (yellowNinja.isPlayerOnRange)
        {
            animator.SetTrigger("PlayerDetected");
            animator.ResetTrigger("Activate");
        }
        if (yellowNinja.isHurt)
        {
            yellowNinja.Stop();
            animator.SetTrigger("Hurt");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Hurt");
        yellowNinja.isHurt = false;
    }

}
