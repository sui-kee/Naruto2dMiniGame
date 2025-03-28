using System.Collections;
using UnityEngine;

public class SnakeSummoner : MonoBehaviour
{
    [SerializeField] private GameObject big_snake;
    [SerializeField] private GameObject shatter_rock;
    public float rock_shatter_speed = 0.4f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke(nameof(RemoveSnake), 1.20f);
        StartCoroutine(SummonBigSnake());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SummonBigSnake()
    {
        big_snake.SetActive(true);
        yield return new WaitForSeconds(rock_shatter_speed);   
        shatter_rock.SetActive(true);
    }

    private void RemoveSnake()
    {
        Destroy(gameObject);
    }
}
