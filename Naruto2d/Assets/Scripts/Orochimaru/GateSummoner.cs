using System.Collections;
using UnityEngine;

public class GateSummoner : MonoBehaviour
{
    [SerializeField] private GameObject gate1;
    [SerializeField] private GameObject gate2;
    [SerializeField] private GameObject gate3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SummonGates());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SummonGates()
    {
        gate1.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        gate2.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        gate3.SetActive(true);
    }
}
