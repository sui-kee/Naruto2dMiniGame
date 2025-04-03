using UnityEngine;

public class AnbuGroundedState : StateMachineBehaviour
{
    Anbu anbu;
    AnbuBody anbuBody;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        anbu = animator.GetComponent<Anbu>();
        anbuBody = GameObject.FindGameObjectWithTag("AnbuBody").GetComponent<AnbuBody>();
        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (anbuBody.player_anbu_distance <= 14.2f && anbu.IsGrounded())
        {
            animator.SetTrigger("WaterJutsu");
        }
        if (anbuBody.player_anbu_distance >= 16.2f )
        {
            animator.SetTrigger("Relocate");
        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Relocate");
        animator.ResetTrigger("WaterJutsu");
        animator.ResetTrigger("Grounded");
    }

}
