using System.Collections;
using UnityEngine;

public class ItachiKick : MonoBehaviour
{
    [SerializeField] private Itachi itachi;
    [SerializeField] private GameObject skillDamageBox;
    [SerializeField] private Transform enemyPos;
    private bool canKick = true;
    private Transform originalPos;
    public float spondingPos = 3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
            originalPos = itachi.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && !itachi.isAttacking && canKick)
        {
            canKick = false;
            itachi.isAttacking = true;
            StartCoroutine(ItachiKickSkill());
        }
    }

    private IEnumerator ItachiKickSkill()
    {
        itachi.comingAnimation = "ItachiKick";
        itachi.rb.gravityScale = 0f;
        yield return new WaitForSeconds(0.30f);
        //itachi.rb.gravityScale = 1f;
        itachi.transform.position = new Vector2(enemyPos.position.x, enemyPos.position.y+spondingPos);
        yield return new WaitForSeconds(0.35f);
        //itachi.transform.position = new Vector2(enemyPos.position.x, enemyPos.position.y + 1f);
        skillDamageBox.SetActive(true);
        yield return new WaitForSeconds(0.07f);
        itachi.rb.gravityScale = 1f;
        skillDamageBox.SetActive(false);
        //itachi.transform.position = new Vector2(originalPos.position.x,originalPos.position.y+1f);
        canKick = true;
        itachi.isAttacking = false;
    }
}
