using System.Collections;
using UnityEngine;

public class OroHurt : MonoBehaviour
{
    [SerializeField] private Orochimaru oro;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(oro.aboveHurt && oro.rb.linearVelocity.y > 0)
        {

        }
    }
}
