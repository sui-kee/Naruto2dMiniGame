using UnityEngine;

public class OroFlyingDetector : MonoBehaviour
{
    Orochimaru oro;
    public bool canJump = false;
    public bool jumpMode = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        oro = GameObject.FindGameObjectWithTag("Orochimaru").GetComponent< Orochimaru>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canJump)
        {
            jumpMode = true;
        }
        else if (jumpMode)
        {
            jumpMode = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("normalDamage") && !oro.isHurt && oro.IsGrounded())
        {
            canJump = true ;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("normalDamage"))
        {
            canJump = false ;
        }
    }
}
