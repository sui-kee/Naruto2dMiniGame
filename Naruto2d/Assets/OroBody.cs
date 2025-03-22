using UnityEngine;

public class OroBody : MonoBehaviour
{
    [SerializeField] private Orochimaru oro;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag.ToString().ToLower().Contains("belowd"))
    //    {
    //        oro.belowHurt = true;
    //        oro.isHurt = true;
    //    }
    //    if (collision.gameObject.tag.ToString().ToLower().Contains("aboved"))
    //    {
    //        oro.aboveHurt = true;
    //        oro.isHurt = true;
    //    }
    //    if (collision.gameObject.tag.ToString().ToLower().Contains("horizontald"))
    //    {
    //        oro.horizontalHurt = true;
    //        oro.isHurt = true;
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.ToString().ToLower().Contains("belowd"))
        {
            oro.belowHurt = true;
            oro.isHurt = true;
        }
        if (collision.gameObject.tag.ToString().ToLower().Contains("aboved"))
        {
            oro.aboveHurt = true;
            oro.isHurt = true;
        }
        if (collision.gameObject.tag.ToString().ToLower().Contains("horizontald"))
        {
            oro.horizontalHurt = true;
            oro.isHurt = true;
        }
        if (collision.gameObject.tag.ToString().ToLower().Contains("normaldamage"))
        {
            oro.normalHurt = true;
            oro.isHurt = true;  
        }
    }
}
