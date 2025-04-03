using UnityEngine;

public class AnbuJutsuState : StateMachineBehaviour
{
    AnbuWaterJutsu jutsu;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        jutsu = GameObject.FindGameObjectWithTag("AnbuEnemy").GetComponentInChildren<AnbuWaterJutsu>();
        jutsu.SummonWaterDragon();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (jutsu.canSummon)
        {
            animator.ResetTrigger("OnJutsu");
            animator.SetTrigger("Grounded");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }


}
