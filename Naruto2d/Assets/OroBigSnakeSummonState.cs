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
        oro.Stop();
        if(detector.ShouldSummonSnake() && summonSnake.canSummon && !oro.isHurt)
        {
            summonSnake.SummonSnake();
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}
