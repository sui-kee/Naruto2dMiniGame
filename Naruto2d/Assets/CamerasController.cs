using Unity.Cinemachine;
using UnityEngine;

public class CamerasController : MonoBehaviour
{
    [SerializeField] private GameObject playerCam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            playerCam.SetActive(false);
        }
        else
        {
            playerCam.SetActive(true);  
        }
    }
}
