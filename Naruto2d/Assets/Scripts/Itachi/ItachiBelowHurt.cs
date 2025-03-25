using System.Collections;
using UnityEngine;

public class ItachiBelowHurt : MonoBehaviour
{
    [SerializeField] private GameObject itachiRunBody;
    Itachi itachi;
    public bool isHurtFromBelow = false;
    public bool isFalling = false;  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        itachi = GameObject.FindGameObjectWithTag("Player").GetComponent<Itachi>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isHurtFromBelow)
        {
            isHurtFromBelow = false ;
            StartCoroutine(ItachiBelowDamage());
        }
        if (isFalling)
        {
            StartCoroutine(BodyHurtBehaviour());
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag.ToString().ToLower().Contains("belowd"))
    //    {
    //        StartCoroutine(ItachiBelowDamage());
    //    }
        
    //}

    public IEnumerator ItachiBelowDamage()
    {
        itachiRunBody.SetActive(false);
        itachi.isHurt = true;
        itachi.comingAnimation = "ItachiBelowDS";
        yield return new WaitForSeconds(0.4f);
        itachi.comingAnimation = "ItachBelowDE";
        isFalling = true;

    }

    private IEnumerator BodyHurtBehaviour()
    {
        if (itachi.isHurt && itachi.currentAnimation == "ItachBelowDE" && itachi.IsGrounded())
        {
            itachi.comingAnimation = "ItachiDie";
            itachiRunBody.SetActive (true);
            yield return new WaitForSeconds(2f);
            itachi.comingAnimation = "ItachiRevive";
            yield return new WaitForSeconds(0.45f);
            itachi.isHurt=false;
            isFalling=false;
        }
    }
}
