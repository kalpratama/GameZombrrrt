using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootsteps : MonoBehaviour
{
    public AudioSource footstepSource; // Assign this in the Inspector
    public AudioClip footstepClip;     // Assign the footstep clip in the Inspector
    public AudioClip sprintFootstepClip;
    public float walkInterval = 0.5f;
    public float sprintInterval = 0.3f;
    public CharacterController controller;

    private float nextFootstepTime = 0f;

    void Update()
    {
        // Check if the player is moving
        if (controller.isGrounded && controller.velocity.magnitude > 0.1f)
        {
            bool isSprinting = Input.GetKey(KeyCode.LeftShift); // Assuming Left Shift is for sprinting
            float interval = isSprinting ? sprintInterval : walkInterval;

            // Play footstep sound at intervals
            if (Time.time >= nextFootstepTime)
            {
                nextFootstepTime = Time.time + interval;
                footstepSource.clip = isSprinting ? sprintFootstepClip : footstepClip;
                footstepSource.Play();
            }
        }
    }
}
