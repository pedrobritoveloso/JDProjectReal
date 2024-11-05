using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandfatherclockSound : MonoBehaviour
{
    public AudioClip clockSound; // Assign your audio clip in the inspector
    private AudioSource audioSource;
    private Collider clockCollider; // Reference to the collider

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        clockCollider = GetComponent<Collider>(); // Get the collider attached to this GameObject
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger is tagged as "Player"
        if (other.CompareTag("Player")) // Make sure your player GameObject has the tag "Player"
        {
            PlaySound();
        }
    }

    private void PlaySound()
    {
        if (audioSource != null && clockSound != null)
        {
            audioSource.PlayOneShot(clockSound); // Play the sound once
            clockCollider.enabled = false; // Disable the collider after playing the sound
        }
    }
}
