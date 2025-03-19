using UnityEngine;

public class BigSnake : MonoBehaviour
{
    [SerializeField] private Transform moveTo;
    public float speed = 6f;
    public float removingTime = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke(nameof(RemoveSnake), removingTime);
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

    private void RemoveSnake()
    {
        Destroy(gameObject);    
    }
}
