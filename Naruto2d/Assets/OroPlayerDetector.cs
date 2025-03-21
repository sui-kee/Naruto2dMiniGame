using UnityEngine;

public class OroPlayerDetector : MonoBehaviour
{
    [SerializeField] private Orochimaru oro;
    [SerializeField] private Itachi itachi;
    [Header("........Ranges........")]
    public float detectRange = 8f;
    public float stopRange = 1f;
    public float snakeSummonRange = 5f;
    public float player_oro_distance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player_oro_distance = Vector2.Distance(itachi.rb.transform.position, oro.rb.transform.position);
    }

    public bool PlayerIsOnSight()
    {
        float distance = Vector2.Distance(itachi.rb.transform.position, oro.rb.transform.position);
        return distance <= detectRange;
    }

    public bool ShouldChase()
    {
        if(player_oro_distance <= stopRange)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public bool ShouldPhysicalAttack()
    {
        if(player_oro_distance <= stopRange && itachi.rb.position.y<-1.12f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool ShouldSummonSnake()
    {
        return player_oro_distance < snakeSummonRange && player_oro_distance > 3;
    }

    public bool PlayerHorizontalIsHigh()
    {
        if (itachi.rb.position.y > -1.5f)
        {
            return true;
        }
        else 
        {
            return false;
        }
    }
}
