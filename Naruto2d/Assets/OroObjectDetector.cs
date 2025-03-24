using System.Collections.Generic;
using UnityEngine;

public class OroObjectDetector : MonoBehaviour
{
    Orochimaru oro;
    public List<GameObject> detectedObjects = new ();
    public GameObject normalDamageObj = null;
    public float closeRange = 4f;// to initiate the jumping mode range, the range of the obj coming and oro 
    public bool canJump = false;

    public bool normalDamageInClose = false;

    private void Start()
    {
        oro = GameObject.FindGameObjectWithTag("Orochimaru").GetComponent<Orochimaru>();
        CheckForNormalDamage();
    }
    private void Update()
    {
        if (normalDamageObj != null)
        {
            float distance = Vector2.Distance(normalDamageObj.transform.position, oro.transform.position);
            if (distance <= closeRange && normalDamageObj.transform.position.x > oro.transform.position.x)
            {
                canJump = true;
            }
            else if((distance <= closeRange && !oro.isFacingRight && normalDamageObj.transform.position.x < oro.transform.position.x))
            {
                canJump = true;
            }
            else
            {
                canJump= false;
            }

        } 
        else
        {
            canJump = false;
        }
        //CheckForNormalDamage();// live update for normalDamage obj
        //if (normalDamageObj != null)
        //{
        //    Debug.Log($" obj live x position : {normalDamageObj.transform.position.x}");
        //}
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!detectedObjects.Contains(other.gameObject))
        {
            detectedObjects.Add(other.gameObject);
            if (other.gameObject.CompareTag("normalDamage"))
            {
                normalDamageObj = other.gameObject;
            }
            //CheckForNormalDamage();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (detectedObjects.Contains(other.gameObject))
        {
            detectedObjects.Remove(other.gameObject);
            if (other.gameObject.CompareTag("normalDamage"))
            {
                normalDamageObj = null;
            }
            //CheckForNormalDamage(); // Recheck when an object leaves
        }
    }

    private void CheckForNormalDamage()
    {
        foreach (GameObject obj in detectedObjects)
        {
            if (obj != null && obj.CompareTag("normalDamage"))
            {
                normalDamageObj = obj;
                return; // exit loop once found
            }
        }
        // only set to null if didn't find any valid objects
        if (normalDamageObj != null && !detectedObjects.Contains(normalDamageObj))
        {
            normalDamageObj = null;
        }
    }

    private void PerformAction(GameObject obj)
    {
        Debug.Log("Detected normalDamage: " + obj.name);
        // Add your action here, e.g., reduce health, apply effect, etc.
    }
}
