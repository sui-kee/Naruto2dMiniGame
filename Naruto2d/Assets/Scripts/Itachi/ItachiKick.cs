using System.Collections;
using UnityEngine;

public class ItachiKick : MonoBehaviour
{
    [SerializeField] private Itachi itachi;
    [SerializeField] private GameObject skillDamageBox;
    [SerializeField] private Transform enemyPos;
    [SerializeField] private GameObject body1;
    [SerializeField] private GameObject body2;
    private bool canKick = true;
    public bool isKicking = false;
    public float spondingPos = 3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && !itachi.isAttacking && !itachi.isHurt )
        {
            itachi.isAttacking = true;
            StartCoroutine(ItachiKickSkill());
        }
    }

    private IEnumerator ItachiKickSkill()
    {
        if(canKick && !isKicking)
        {
            //itachi.tag = "ItachiKickAboveD";// there is a problem of tag name that reach to the target, add this to ensure the tag reach to enemy is * ItachiKickAboveD*
            float kickingRePosition = itachi.isFacingRight ? -0.5f : 0.5f;// for position to direct hit with leg 
            canKick = false;
            isKicking=true;
            itachi.isSpecialKicking = true;

            itachi.comingAnimation = "ItachiKick";
            itachi.rb.gravityScale = 0f;
            body1.SetActive(false);
            body2.SetActive(false);
            yield return new WaitForSeconds(0.30f);
            //itachi.rb.gravityScale = 1f;
            itachi.transform.position = new Vector2(enemyPos.position.x + kickingRePosition, enemyPos.position.y+spondingPos);
            //itachi.transform.position = new Vector2(enemyPos.position.x, enemyPos.position.y + 1f);

            yield return new WaitForSeconds(0.36f);
            skillDamageBox.SetActive(true);
            itachi.rb.gravityScale = 1f;

            yield return new WaitForSeconds(0.39f); // Ensuring animation completes (1.05 - 0.30 - 0.36)
            //itachi.tag = "Player";
            itachi.isSpecialKicking=false;
            skillDamageBox.SetActive(false);
            body1.SetActive(true);
            body2.SetActive(true);
            canKick = true;
            isKicking = false;
            itachi.isAttacking = false;
        }
    }
}
