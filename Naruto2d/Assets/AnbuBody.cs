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
        if (!collision.gameObject.CompareTag("Wall"))
        {
            anbu.isHurt = true;
        }
    }
}
