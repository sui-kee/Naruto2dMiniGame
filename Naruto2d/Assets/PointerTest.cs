using System.Collections;
using UnityEngine;

public class PointerTest : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Rigidbody2D rb;
    //[SerializeField] private GameObject bullect;
    //[SerializeField] private Transform shootingPoint;
    public Vector2 direction;
    public float angle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        direction = (target.position - transform.position).normalized;

        // Rotate to face player
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        //StartCoroutine(ShootPlayer());
    }

    //private IEnumerator ShootPlayer()
    //{
    //    if(canShoot)
    //    {
    //        canShoot = false;   
    //        Instantiate(bullect, shootingPoint.position, shootingPoint.rotation);
    //        yield return new WaitForSeconds(shootCoolDown);
    //        canShoot=true;
    //    }
    //}
}
