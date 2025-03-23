using System.Collections.Generic;
using UnityEngine;

public class OroObjectDetector : MonoBehaviour
{
    private List<GameObject> detectedObjects = new List<GameObject>();

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!detectedObjects.Contains(other.gameObject))
        {
            detectedObjects.Add(other.gameObject);
            CheckForNormalDamage();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (detectedObjects.Contains(other.gameObject))
        {
            detectedObjects.Remove(other.gameObject);
            CheckForNormalDamage(); // Recheck when an object leaves
        }
    }

    private void CheckForNormalDamage()
    {
        foreach (GameObject obj in detectedObjects)
        {
            if (obj.name.Contains("normalDamage")) // Checking if name contains "normalDamage"
            {
                PerformAction(obj);
                break; // Action done, no need to check further
            }
        }
    }

    private void PerformAction(GameObject obj)
    {
        Debug.Log("Detected normalDamage: " + obj.name);
        // Add your action here, e.g., reduce health, apply effect, etc.
    }
}
