using UnityEngine;

public class OroBigSnakeSummonState : StateMachineBehaviour
{
    OroPlayerDetector detector;
    OroSummonSnake summonSnake;
    Orochimaru oro;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        detector = animator.GetComponent<OroPlayerDetector>();
        summonSnake = animator.GetComponent<OroSummonSnake>();
        oro = animator.GetComponent<Orochimaru>();
    }
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        oro.rb.linearVelocity = new Vector2(0f,oro.rb.linearVelocity.y);// stop horizontally
        if( summonSnake.canSummon && !oro.isHurt)//detector.ShouldSummonSnake() &&
        {
            summonSnake.SummonSnake();
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}
