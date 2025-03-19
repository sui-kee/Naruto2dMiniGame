using UnityEngine;

public class DelvilWall1 : MonoBehaviour
{
    [SerializeField] private Transform moveTo;
    public float speed = 1f;
    public float remove_speed = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke(nameof(RemoveWall), remove_speed);
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

    private void RemoveWall()
    {
        Destroy(gameObject);
    }
}
