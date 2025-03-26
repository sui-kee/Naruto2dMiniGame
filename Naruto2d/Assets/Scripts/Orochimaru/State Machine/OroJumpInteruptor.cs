using UnityEngine;

public class OroJumpInteruptor : StateMachineBehaviour
{
    Orochimaru oro;
    //OroFlyingDetector oroFlyingDetector;
    OroObjectDetector oroObjectDetector;
    public float jumping_power = 9f;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        oroObjectDetector = GameObject.FindGameObjectWithTag("OroObjectDetector").GetComponent<OroObjectDetector>();
        oro = animator.GetComponent<Orochimaru>();
        //oroFlyingDetector = GameObject.FindGameObjectWithTag("OroFlyDetector").GetComponent<OroFlyingDetector>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (oroObjectDetector.canJump && oro.IsGrounded() && !oro.isHurt)
        {
            animator.SetTrigger("Jump");
            animator.ResetTrigger("Idle");
            animator.ResetTrigger("DetectP");
            animator.ResetTrigger("HorizontalDetect");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
