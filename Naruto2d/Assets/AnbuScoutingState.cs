using UnityEngine;

public class AnbuScoutingState : StateMachineBehaviour
{
    AnbuBody body;
    Anbu anbu;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        anbu = animator.GetComponent<Anbu>();   
        body = GameObject.FindGameObjectWithTag("AnbuBody").GetComponent<AnbuBody>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        anbu.rb.gravityScale = 0f;
        if(body.player_anbu_distance <= 14f)
        {
            animator.SetTrigger("Detect");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        anbu.rb.gravityScale = 1f;
    }

}
