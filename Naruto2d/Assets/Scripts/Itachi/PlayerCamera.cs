using Unity.Cinemachine;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Itachi player;
    [SerializeField] private CinemachineFollow CinemachineFollow;
    [SerializeField] private CinemachineCamera mainCamera;
    [SerializeField] private Kunai kunai;
    public float camera_facing_offset = 3.84f;
    public float smoothSpeed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.S) && player.throwingKunai)
        {
            Transform kunaiPos = GameObject.FindGameObjectWithTag("KunaiNormalDamage").transform;
            mainCamera.Follow = kunaiPos;
        }
        else
        {
            mainCamera.Follow = player.transform;   
        }
        float targetOffsetX = player.isFacingRight ? camera_facing_offset : -camera_facing_offset;

        // Smoothly interpolate the x offset
        CinemachineFollow.FollowOffset.x = Mathf.Lerp(CinemachineFollow.FollowOffset.x, targetOffsetX, Time.deltaTime * smoothSpeed);
    }
}
