using System.Collections;
using UnityEngine;

public class AnbuRelocateJutsu : MonoBehaviour
{
    [SerializeField] private Anbu anbu;
    [SerializeField] private Itachi itachi;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Relocation()
    {
        Vector2 newPos = new Vector2(itachi.transform.position.x - 5f,itachi.transform.position.y + 0.1f);
        anbu.transform.position = newPos;    
    }

    public void RelocateNearPlayer()
    {
        Invoke(nameof(Relocation), 0.1f);
    }
}
