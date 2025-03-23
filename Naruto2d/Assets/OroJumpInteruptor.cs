using UnityEngine;

public class OroJumpInteruptor : StateMachineBehaviour
{
    Orochimaru oro;
    public float jumping_power = 9f;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        oro = animator.GetComponent<Orochimaru>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //if (GameObject.FindGameObjectWithTag("normalDamage").transform)
        //{
        //    Transform incomingDamage = GameObject.FindGameObjectWithTag("normalDamage").transform;
        //    if (incomingDamage != null && Vector2.Distance(oro.transform.position, incomingDamage.position) < 4)
        //    {
        //        oro.rb.linearVelocity = new Vector2(0f, jumping_power);
        //        animator.ResetTrigger("Idle");
        //        animator.SetTrigger("Jump");
        //    }
        //} TO FIX
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
