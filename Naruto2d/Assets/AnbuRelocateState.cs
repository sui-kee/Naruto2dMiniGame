using UnityEngine;

public class AnbuRelocateState : StateMachineBehaviour
{
    Anbu anbu;
    AnbuRelocateJutsu relocate;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        relocate = animator.GetComponent<Anbu>().GetComponentInChildren<AnbuRelocateJutsu>();
        anbu = animator.GetComponent<Anbu>();
        relocate.RelocateNearPlayer();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
