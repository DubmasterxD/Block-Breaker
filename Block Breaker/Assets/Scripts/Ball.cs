using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] private Pad pad = null;
    private Vector2 padToBallVector = new Vector2();
    [SerializeField] private Vector2 startingVelocity = new Vector2(2f, 15f);
    private bool hasStarted = false;
    private AudioSource audioSource = null;
    [SerializeField] private AudioClip[] bounceSounds;

    // Start is called before the first frame update
    void Start()
    {
        padToBallVector = transform.position - pad.transform.position;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPad();
            LaunchOnMouseClick();
        }
    }

    private void LaunchOnMouseClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = startingVelocity;
        }
    }

    private void LockBallToPad()
    {
        Vector2 padPos = new Vector2(pad.transform.position.x, pad.transform.position.y);
        transform.position = padPos + padToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted)
        {
            AudioClip clip = bounceSounds[Random.Range(0, bounceSounds.Length)];
            audioSource.PlayOneShot(clip);
        }
    }
}
