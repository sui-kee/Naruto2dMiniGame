using UnityEngine;

public class OroOnRun : StateMachineBehaviour
{
    OroPlayerDetector detector;
    Orochimaru oro;
    OroSummonSnake summonSnake;
    Itachi player;
    OroSummonGates gates;
    public bool shouldPhysicalAttack = false;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        gates = animator.GetComponent<OroSummonGates>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Itachi>();
        summonSnake = animator.GetComponent< OroSummonSnake>();
        detector = animator.GetComponent< OroPlayerDetector>(); 
        oro = animator.GetComponent<Orochimaru>();
        oro.isHurt = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //auto change directions
        oro.ChangeDirection();
        // auto movements
        if(!detector.ShouldPhysicalAttack())// oro should stop moving while giving the attack
        {
            oro.MoveToPlayer();
        }else if(detector.ShouldPhysicalAttack())
        {
            oro.Stop();
        }


        if (oro.aboveHurt)
        {
            oro.isIdle = true;// to stop the player movements
            animator.SetTrigger("AboveHurt");
        }
        if(gates.canSummon && player.IsGrounded() && detector.PlayerIsOnRangeToSummonGate() && !oro.isHurt)
        {
            animator.SetTrigger("DevilGates");
        }
        if (detector.ShouldSummonSnake() && summonSnake.canSummon)
        {
            animator.SetTrigger("SnakeSummon");
        }
        if (detector.ShouldPhysicalAttack() && !detector.PlayerHorizontalIsHigh())
        {
            animator.SetTrigger("PhysicalAttack");
        }
        if (!player.IsGrounded() || !detector.PlayerIsOnSight())
        {
            animator.SetTrigger("DetectP");
            animator.ResetTrigger("HorizontalDetect");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("AboveHurt");
        animator.ResetTrigger("PhysicalAttack");
        animator.ResetTrigger("SnakeSummon");
        animator.ResetTrigger("DevilGates");
    }

}
