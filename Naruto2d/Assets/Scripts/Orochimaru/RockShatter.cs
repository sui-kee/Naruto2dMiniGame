using UnityEngine;

public class RockShatter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke(nameof(RemoveRock), 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void RemoveRock()
    {
        Destroy(gameObject);
    }
}
