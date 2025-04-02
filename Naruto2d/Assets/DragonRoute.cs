using UnityEngine;

public class DragonRoute : MonoBehaviour
{
    [SerializeField] private Transform nextRoute;// when the dragon reach this gameobj route and must church to this next route 
    [SerializeField] private DragonGate dragonGate;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("WaterDragon"))
        {
            dragonGate.dragon_target = nextRoute;
            Destroy(gameObject);
        }
    }
}
