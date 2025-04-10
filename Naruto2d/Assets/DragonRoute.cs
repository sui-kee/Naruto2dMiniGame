using UnityEngine;

public class DragonRoute : MonoBehaviour
{
    [SerializeField] private DragonGate dragonGate;
    public Transform next_route;// when the dragon reach this gameobj route and must church to this next route 
    public bool lastRoute = false;
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
        if (collision.CompareTag("WaterDragon") || collision.CompareTag("BelowD"))
        {
            Transform nextRoute = lastRoute ? dragonGate.anbu.itachi.transform : next_route;
            dragonGate.dragon_target = nextRoute;
            Destroy(gameObject);
        }
    }
}
