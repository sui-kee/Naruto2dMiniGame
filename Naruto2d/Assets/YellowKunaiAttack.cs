using System.Collections;
using UnityEngine;

public class YellowKunaiAttack : MonoBehaviour
{
    [SerializeField] private GameObject kunai;
    [SerializeField] private Transform shootingPoint;
    [SerializeField] private YellowNinja ninja;
    public bool canShoot = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public IEnumerator KunaiAttack()
    {
        canShoot = false;
        yield return new WaitForSeconds(0.45f);
        Instantiate(kunai, shootingPoint.position, shootingPoint.rotation);
        yield return new WaitForSeconds(5f);
        canShoot = true;
    }

    public void Shoot()
    {
        StartCoroutine(KunaiAttack());  
    }
}
