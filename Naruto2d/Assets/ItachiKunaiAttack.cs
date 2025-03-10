using System.Collections;
using UnityEngine;

public class ItachiKunaiAttack : MonoBehaviour
{
    [SerializeField] private GameObject kunai;
    [SerializeField] private Transform shootingPoint;
    [SerializeField] private Itachi itachi;
    private bool canShoot = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && canShoot)
        {
            canShoot = false;
            StartCoroutine(KunaiAttack());
        }
    }

    private IEnumerator KunaiAttack()
    {
        itachi.isAttacking = true;
        itachi.comingAnimation = "ItachiKunai";
        yield return new WaitForSeconds(0.88f);
        Instantiate(kunai, shootingPoint.position, shootingPoint.rotation);
        itachi.isAttacking = false;
        canShoot = true;
    }
}
