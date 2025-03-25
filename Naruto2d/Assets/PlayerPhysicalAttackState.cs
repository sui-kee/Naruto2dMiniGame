using UnityEngine;

public class PlayerPhysicalAttackState : StateMachineBehaviour
{
    Orochimaru oro;
    OroSummonSnake summonSnake;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        summonSnake = animator.GetComponent< OroSummonSnake>();
        oro = animator.GetComponent< Orochimaru>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        oro.rb.linearVelocity = new Vector2(0f,oro.rb.linearVelocity.y);// stop horizontally
        if (summonSnake.canSummon)//detector.ShouldSummonSnake() &&
        {
            animator.SetTrigger("SnakeSummon");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("SnakeSummon");
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
