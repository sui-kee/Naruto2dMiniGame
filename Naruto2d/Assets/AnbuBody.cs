using UnityEngine;

public class AnbuBody : MonoBehaviour
{
    [SerializeField] private Anbu anbu;
    [SerializeField] private Itachi player;
    public float player_anbu_distance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        player_anbu_distance = Vector2.Distance(player.transform.position, transform.position);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log($"hit by:{collision.gameObject.tag}");
        if (collision.gameObject.CompareTag("ItachiKickAboveD"))
        {
            anbu.isHurt = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"hit by:{collision.gameObject.tag}");
        if (collision.CompareTag("ItachiKickAboveD"))
        {
            anbu.isHurt = true;
        }
    }
}
