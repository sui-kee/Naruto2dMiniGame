using UnityEngine;

public class OroSummonGateState : StateMachineBehaviour
{
    Orochimaru oro;
    OroSummonGates summonGate;
    OroPlayerDetector playerDetector;
    Itachi itachi;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        itachi = GameObject.FindGameObjectWithTag("Player").GetComponent<Itachi>();
        oro = animator.GetComponent< Orochimaru>();
        playerDetector = animator.GetComponent<OroPlayerDetector>();
        summonGate = animator.GetComponent< OroSummonGates>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        oro.rb.linearVelocity = new Vector2(0f, oro.rb.linearVelocity.y);// stop horizontally
        
        if(summonGate.canSummon && !oro.isHurt)
        {
            summonGate.SummonGates();
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }


}
