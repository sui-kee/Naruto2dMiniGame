using System.Collections;
using UnityEngine;

public class OroShootSnakeUp : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private GameObject snake;
    [SerializeField] private Transform shootingPoint;
    Orochimaru oro;
    public Vector2 direction;
    public float angle;
    public bool canShoot = true;
    public float shootCoolDown = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        oro = gameObject.GetComponent< Orochimaru>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = (target.position - transform.position).normalized;

        // Rotate to face player
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    }

    private IEnumerator ShootSnake()
    {
        if (canShoot)
        {
            canShoot = false;
            oro.isAttacking = true;
            if (oro.isHurt)
            {
                canShoot = true;
                oro.isAttacking = false;
                yield break;
            }
            yield return new WaitForSeconds(0.40f);

                Instantiate(snake, shootingPoint.position, shootingPoint.rotation);
                yield return new WaitForSeconds(0.45f);
                oro.isAttacking = false;
                yield return new WaitForSeconds(shootCoolDown);
                canShoot = true;

            
        }
    }

    public void ShootPlayer()
    {
        StartCoroutine(ShootSnake());
    }
}
