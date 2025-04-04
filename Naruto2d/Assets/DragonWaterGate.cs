using System.Collections;
using UnityEngine;

public class DragonWaterGate : MonoBehaviour
{
    [SerializeField] private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(WaterGateBehaviour());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator WaterGateBehaviour()
    {
        yield return new WaitForSeconds(0.40f);
        animator.CrossFade("WaterGateE",0f);
    }
}
