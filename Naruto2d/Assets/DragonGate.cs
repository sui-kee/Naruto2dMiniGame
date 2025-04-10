using UnityEngine;

public class DragonGate : MonoBehaviour
{
    [SerializeField] private Transform route1;
    [SerializeField] private Transform route2;
    [SerializeField] private Transform route3;
    [SerializeField] private GameObject waterGate;
    [SerializeField] private GameObject dragon;
    public Anbu anbu;
    public Transform dragon_target;// define the target that the dragon should after
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anbu = GameObject.FindGameObjectWithTag("AnbuEnemy").GetComponent<Anbu>();
        dragon_target = route1;
        waterGate.SetActive(true);
        Invoke(nameof(ActivateDragon), 0.43f);
    }

    // Update is called once per frame
    void Update()
    {
        if (anbu.isHurt)
        {
            Destroy(gameObject);
        }
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
