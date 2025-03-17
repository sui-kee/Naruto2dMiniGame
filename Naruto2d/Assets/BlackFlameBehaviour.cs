using System.Collections;
using UnityEngine;

public class BlackFlameBehaviour : MonoBehaviour
{
    [SerializeField] private Animator Animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(BlackFlameBurning());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator BlackFlameBurning()
    {
        yield return new WaitForSeconds(0.35f);
        Animator.CrossFade("BlackFlame", 0.1f);
        yield return new WaitForSeconds(3f);
        Animator.CrossFade("BlackFlameExtinguish", 0.1f);
        yield return new WaitForSeconds(0.35f);
        Destroy(gameObject);
    }
}
