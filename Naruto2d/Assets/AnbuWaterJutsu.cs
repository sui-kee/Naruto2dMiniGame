using System.Collections;
using UnityEngine;

public class AnbuWaterJutsu : MonoBehaviour
{
    [SerializeField] private Anbu anbu;
    [SerializeField] private Transform summoingPos;
    [SerializeField] private GameObject dragon;
    public bool canSummon = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SummonWaterDragon()
    {
        canSummon = false;
        Instantiate(dragon, summoingPos.position, transform.rotation);
    }
}
