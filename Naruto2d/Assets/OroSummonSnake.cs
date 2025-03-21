using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class OroSummonSnake : MonoBehaviour
{
    [SerializeField] private GameObject BigSnake;
    [SerializeField] private Itachi player;
    [SerializeField] private Orochimaru oro;
    [SerializeField] private OroPlayerDetector detector;
    public bool canSummon = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator BigSnakeSummonBehaviour()
    {
        oro.isAttacking = true;
        canSummon = false;
        //float predictMovement = player.isFacingRight ? 1f : -1f;
        yield return new WaitForSeconds(0.50f);
        if (oro.isHurt)
        {
            yield break;
        }
        else
        {
            Vector2 summoningPos = new Vector2(player.transform.position.x, -2.88f);
            Instantiate(BigSnake, summoningPos, oro.rb.transform.rotation);
            yield return new WaitForSeconds(1.10f);
            
        }
            oro.isAttacking = false;
            yield return new WaitForSeconds(4f);
            canSummon = true;
    }

    public void SummonSnake()
    {
        StartCoroutine(BigSnakeSummonBehaviour());
    }


}
