using System.Collections;
using UnityEngine;

public class PointerTest : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private GameObject bullect;
    [SerializeField] private Transform shootingPoint;
    public Vector2 direction;
    public float angle;
    public bool canShoot = true;
    public float shootCoolDown = 1f;
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
        StartCoroutine(ShootPlayer());
    }

    private IEnumerator ShootPlayer()
    {
        if(canShoot)
        {
            canShoot = false;   
            Instantiate(bullect, shootingPoint.position, shootingPoint.rotation);
            yield return new WaitForSeconds(shootCoolDown);
            canShoot=true;
        }
    }
}
