using UnityEngine;

public class DragonGate : MonoBehaviour
{
    [SerializeField] private Transform route1;
    [SerializeField] private Transform route2;
    [SerializeField] private Transform route3;
    [SerializeField] private GameObject waterGate;
    [SerializeField] private GameObject dragon;
    public Transform dragon_target;// define the target that the dragon should after
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dragon_target = route1;
        Invoke(nameof(ActivateGate), 1f);
        Invoke(nameof(ActivateDragon), 1.8f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ActivateGate()
    {
        waterGate.SetActive(true);
    }

    private void ActivateDragon()
    {
        dragon.SetActive(true);
    }
}
