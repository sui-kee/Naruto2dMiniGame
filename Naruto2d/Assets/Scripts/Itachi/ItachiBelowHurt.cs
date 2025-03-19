using System.Collections;
using UnityEngine;

public class ItachiBelowHurt : MonoBehaviour
{
    Itachi itachi;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        itachi = GameObject.FindGameObjectWithTag("Player").GetComponent<Itachi>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(BodyHurtBehaviour());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.ToString().ToLower().Contains("belowd"))
        {
            StartCoroutine(ItachiBelowDamage());
        }
        
    }

    private IEnumerator ItachiBelowDamage()
    {
        itachi.isHurt = true;
        itachi.comingAnimation = "ItachiBelowDS";
        yield return new WaitForSeconds(0.4f);
        itachi.comingAnimation = "ItachBelowDE";

    }

    private IEnumerator BodyHurtBehaviour()
    {
        if (itachi.isHurt && itachi.currentAnimation == "ItachBelowDE" && itachi.IsGrounded())
        {
            itachi.comingAnimation = "ItachiDie";
            yield return new WaitForSeconds(2f);
            itachi.comingAnimation = "ItachiRevive";
            yield return new WaitForSeconds(0.45f);
            itachi.isHurt=false;
        }
    }
}
