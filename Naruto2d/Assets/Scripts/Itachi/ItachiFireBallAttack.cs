using System.Collections;
using UnityEngine;

public class ItachiFireBallAttack : MonoBehaviour
{
    [SerializeField] private GameObject fireBall;
    [SerializeField] private Transform shootingPoint;
    [SerializeField] private Itachi itachi;
    AudioManager audioManager;
    private bool isShooting = false;    
    private bool canShootFire = true;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && canShootFire && !itachi.isAttacking && !itachi.isHurt)
        {
            audioManager.PlaySFX(audioManager.ItachiFireballStart);
            itachi.isAttacking = true;
            canShootFire=false;
            StartCoroutine(FireBallAttack());   
        } 
        if(isShooting)
        {
            itachi.rb.linearVelocity = new Vector2(0f, itachi.rb.linearVelocity.y);
        }
    }

    private IEnumerator FireBallAttack()
    {
        itachi.comingAnimation = "ItachiFireBall";
        yield return new WaitForSeconds(0.40f);
        audioManager.PlaySFX(audioManager.ItachiFireballEnd);
        yield return new WaitForSeconds(1.20f);
        if (!itachi.isHurt)
        {
            Instantiate(fireBall, shootingPoint.position, shootingPoint.rotation);
        }
        itachi.isAttacking = false;
        canShootFire = true ;
    }
}
