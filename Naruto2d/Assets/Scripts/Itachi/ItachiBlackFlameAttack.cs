using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class ItachiBlackFlameAttack : MonoBehaviour
{
    [SerializeField] private GameObject Flame;
    [SerializeField] private Transform EnemyTran;
    [SerializeField] private Itachi itachi;
    private bool isShooting = false;
    private bool canShoot = true;
    public float S_P_reducer = -1f;// shootingPoint reducer for y position
    public float Range;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && canShoot)
        {
            itachi.isAttacking = true;
            isShooting = true;
            canShoot = false;
            StartCoroutine(KunaiAttack());
        }
        if (isShooting)
        {
            itachi.rb.linearVelocity = new Vector2(0f, itachi.rb.linearVelocity.y);
        }
        Range = Vector2.Distance(itachi.transform.position, EnemyTran.transform.position);
    }

    private IEnumerator KunaiAttack()
    {
        Vector2 flamePos = new Vector2(EnemyTran.position.x, EnemyTran.position.y+S_P_reducer);
        itachi.comingAnimation = "ItachiBlackFlame";
        yield return new WaitForSeconds(0.34f);
        Instantiate(Flame, flamePos ,EnemyTran.transform.rotation);
        isShooting = false;
        itachi.isAttacking = false;
        yield return new WaitForSeconds(1f);
        canShoot = true;
    }
}
