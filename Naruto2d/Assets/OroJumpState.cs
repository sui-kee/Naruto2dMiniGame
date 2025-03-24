using UnityEngine;

public class OroJumpState : StateMachineBehaviour
{
    Orochimaru oro;
    OroObjectDetector oroObjectDetector;
    public float jumpPower = 8f;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        oro = animator.GetComponent< Orochimaru>();
        oroObjectDetector = GameObject.FindGameObjectWithTag("OroObjectDetector").GetComponent<OroObjectDetector>();
        if (oro.IsGrounded())
        {
            oro.rb.linearVelocity = new Vector2(oro.rb.linearVelocity.x, jumpPower);
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (oro.rb.linearVelocityY < 0)
        {
            animator.SetTrigger("NormalFall");
            animator.ResetTrigger("Jump");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
