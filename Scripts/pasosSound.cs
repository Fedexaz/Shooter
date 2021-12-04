using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pasosSound : MonoBehaviour
{
    public float stepInterval = 1f; // min interval between steps
    public float stepLength = 0.5f; // distance walked by each step
    public AudioClip[] footsteps; // drag step sounds here

    public AudioSource audioSource;

    private float stepTime;
    private Vector3 lastStep;
 
    void Start()
    {
        lastStep = transform.position; // initialize lastStep position
    }

    void Update()
    {
        // if walked a distance >= stepLength...
        if (Vector3.Distance(transform.position, lastStep) >= stepLength)
        {
            if (Time.time > stepTime)
            { // and it's time to play a new footstep...
              // play a randomly selected sound:
                audioSource.PlayOneShot(footsteps[Random.Range(0, footsteps.Length)]);
                lastStep = transform.position; // update lastStep and stepTime:
                stepTime = Time.time + stepInterval;
            }
        }
    }
}
