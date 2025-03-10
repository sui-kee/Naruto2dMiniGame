using System.Collections;
using UnityEngine;

public class ItachiFireBallAttack : MonoBehaviour
{
    [SerializeField] private GameObject fireBall;
    [SerializeField] private Transform shootingPoint;
    [SerializeField] private Itachi itachi;
    private bool canShootFire = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && canShootFire)
        {
            canShootFire=false;
            StartCoroutine(FireBallAttack());   
        } 
    }

    private IEnumerator FireBallAttack()
    {
        itachi.isAttacking = true;
        itachi.comingAnimation = "ItachiFireBall";
        yield return new WaitForSeconds(1f);
        Instantiate(fireBall, shootingPoint.position, shootingPoint.rotation);
        itachi.isAttacking = false;
        canShootFire = true ;
    }
}
