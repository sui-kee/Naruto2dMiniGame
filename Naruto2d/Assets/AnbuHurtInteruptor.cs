using UnityEngine;

public class AnbuHurtInteruptor : StateMachineBehaviour
{
    AnbuBody body;
    Anbu anbu;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        anbu = animator.GetComponent<Anbu>();
        body = animator.GetComponent<Anbu>().GetComponentInChildren<AnbuBody>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (anbu.isHurt)
        {
            animator.SetTrigger("Hurt");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Hurt");
        anbu.isHurt = false;
    }

}
