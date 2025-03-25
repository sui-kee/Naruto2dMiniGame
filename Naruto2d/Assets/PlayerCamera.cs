using Unity.Cinemachine;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Itachi player;
    [SerializeField] private CinemachineFollow CinemachineFollow;
    public float camera_facing_offset = 3.84f;
    public float smoothSpeed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float targetOffsetX = player.isFacingRight ? camera_facing_offset : -camera_facing_offset;

        // Smoothly interpolate the x offset
        CinemachineFollow.FollowOffset.x = Mathf.Lerp(CinemachineFollow.FollowOffset.x, targetOffsetX, Time.deltaTime * smoothSpeed);
    }
}
