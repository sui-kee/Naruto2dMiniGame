using System.Collections;
using UnityEngine;

public class OroSummonGates : MonoBehaviour
{
    Orochimaru oro;
    OroPlayerDetector oroDetect;
    [SerializeField] private Transform summoingPos;
    [SerializeField] private GameObject devilGates;
    [SerializeField] private float summonCooldown = 3f;
    public bool canSummon = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        oro = gameObject.GetComponent< Orochimaru>();
        oroDetect = gameObject.GetComponent< OroPlayerDetector>();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator GateBehaviour()
    {
        oro.isAttacking = true;
        canSummon = false;
        yield return new WaitForSeconds(0.52f);
        if (!oro.isHurt)
        {
            Instantiate(devilGates, summoingPos.position, summoingPos.rotation);
        }
        yield return new WaitForSeconds(1f);
        oro.isAttacking = false;
        yield return new WaitForSeconds(summonCooldown);
        canSummon = true;
    }

    public void SummonGates()
    {
        StartCoroutine(GateBehaviour());
    }
}
