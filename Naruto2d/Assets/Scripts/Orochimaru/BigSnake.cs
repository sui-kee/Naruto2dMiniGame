using System.Collections;
using UnityEngine;

public class BigSnake : MonoBehaviour
{
    [SerializeField] private Transform moveTo;
    [SerializeField] private Animator animator;
    public float speed = 6f;
    public float removingTime = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(BigSnakeBehaviour());
    }

    // Update is called once per frame
    void Update()
    {
        MoveToPos();
    }
    public void MoveToPos()
    {


        transform.position = Vector2.MoveTowards(transform.position, moveTo.position, speed * Time.deltaTime);

    }

    public IEnumerator BigSnakeBehaviour()
    {
        yield return new WaitForSeconds(removingTime);
        animator.CrossFade("BigSnakeE",0.1f);
    }
    private void RemoveSnake()
    {
        Destroy(gameObject);    
    }
}
