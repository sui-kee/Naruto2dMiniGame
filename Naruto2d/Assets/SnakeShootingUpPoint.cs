using UnityEngine;

public class SnakeShootingUpPoint : MonoBehaviour
{
    Orochimaru oro;
    public bool isFacingRight = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        oro = GameObject.FindGameObjectWithTag("Orochimaru").GetComponent<Orochimaru>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (!oro.isFacingRight)
        //{
        //    transform.Rotate(0f, 180f, 0f);
        //}
    }
}
