using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSound : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip[] soundArray;
    public float mag = 2f;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > mag)
            if (!audioSource.isPlaying)
            {
                audioSource.clip = soundArray[Random.Range(0, soundArray.Length)];
                audioSource.Play();
            }
    }
}
