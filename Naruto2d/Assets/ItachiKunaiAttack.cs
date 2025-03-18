using System.Collections;
using UnityEngine;

public class ItachiKunaiAttack : MonoBehaviour
{
    [SerializeField] private GameObject kunai;
    [SerializeField] private Transform shootingPoint;
    [SerializeField] private Itachi itachi;
    private bool isShooting = false;
    private bool canShoot = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && canShoot && !itachi.isAttacking)
        {
            itachi.isAttacking = true;
            isShooting=true;
            canShoot = false;
            StartCoroutine(KunaiAttack());
        }
        if (isShooting)
        {
            itachi.rb.linearVelocity = new Vector2(0f, itachi.rb.linearVelocity.y);
        }
    }

    private IEnumerator KunaiAttack()
    {
        itachi.comingAnimation = "ItachiKunai";
        yield return new WaitForSeconds(0.07f);
        Instantiate(kunai, shootingPoint.position, shootingPoint.rotation);
        isShooting = false;
        itachi.isAttacking = false;
        yield return new WaitForSeconds(0.5f);
        canShoot = true;
    }
}
