using System.Collections;
using UnityEngine;

public class ItachiKick : MonoBehaviour
{
    [SerializeField] private Itachi itachi;
    [SerializeField] private GameObject skillDamageBox;
    [SerializeField] private GameObject body1;
    [SerializeField] private GameObject body2;
    AudioManager audioManager;
    private bool canKick = true;
    public GameObject target = null;  // when kunai hit target it will lock target and make it kickable
    public bool targetIsEnemy = false; // when kunia hit something this bool will determine whether the target is enemy or object
    public bool isKicking = false;
    public float spondingPos = 3f;
    //public Transform relocationPosition = null;

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
        if (Input.GetKeyDown(KeyCode.C) && !itachi.isAttacking && !itachi.isHurt && target != null)
        {
            if (targetIsEnemy)
            {
                itachi.isSpecialKicking = true;
                itachi.isAttacking = true;
                StartCoroutine(ItachiKickSkill());
            }
            else if (!targetIsEnemy)
            {
                itachi.isAttacking = true;
                StartCoroutine(VanishRelocate());
            }
        }
    }

    private IEnumerator ItachiKickSkill()
    {
        if(canKick && !isKicking )
        {
            audioManager.PlaySFX(audioManager.ItachiTsukyumi);
            //itachi.tag = "ItachiKickAboveD";// there is a problem of tag name that reach to the target, add this to ensure the tag reach to enemy is * ItachiKickAboveD*
            float kickingRePosition = itachi.isFacingRight ? -0.5f : 0.5f;// modify position to direct hit with leg 
            canKick = false;
            isKicking=true;

            itachi.comingAnimation = "ItachiKick";
            itachi.rb.gravityScale = 0f;
            yield return new WaitForSeconds(0.30f);
            //itachi.rb.gravityScale = 1f;
            itachi.transform.position = new Vector2(target.transform.position.x + kickingRePosition, target.transform.position.y+spondingPos);
            //itachi.transform.position = new Vector2(enemyPos.position.x, enemyPos.position.y + 1f);

            yield return new WaitForSeconds(0.36f);
            skillDamageBox.SetActive(true);
            itachi.rb.gravityScale = 1f;
            target = null;// reset target

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
    public IEnumerator VanishRelocate()
    {
        itachi.isAttacking=true;
        //itachi.isSpecialKicking = true;
        audioManager.PlaySFX(audioManager.ItachiTsukyumi);
        Vector2 newPos = new Vector2(target.transform.position.x, target.transform.position.y);
        itachi.comingAnimation = "ItachiVanish";
        yield return new WaitForSeconds(0.30f);
        itachi.transform.position = newPos;
        Destroy(target);
        yield return new WaitForSeconds(0.9f);
        //itachi.isSpecialKicking = false;
        itachi.isAttacking=false;
    }
}
