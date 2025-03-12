using UnityEngine;

public class YellowShoot : StateMachineBehaviour
{
    YellowKunaiAttack shoot;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        shoot = animator.GetComponent<YellowKunaiAttack>();
        shoot.Shoot();
    }

}
