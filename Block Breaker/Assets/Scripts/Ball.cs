using UnityEngine;

public class Ball : MonoBehaviour
{
    // Variables
    [SerializeField] Vector2 startingVelocity = new Vector2(2f, 15f);
    [SerializeField] float randomFactor = 2f;
    [SerializeField] float ballSpeed = 15f;
    Vector2 padToBallVector;
    bool hasStarted = false;

    // References
    Pad pad;
    AudioSource audioSource;
    Rigidbody2D rb2d;
    [SerializeField] AudioClip[] bounceSounds = null;
    
    private void Start()
    {
        pad = FindObjectOfType<Pad>();
        padToBallVector = transform.position - pad.transform.position;
        audioSource = GetComponent<AudioSource>();
        rb2d = GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
        if (!hasStarted)
        {
            LockBallToPad();
            LaunchOnMouseClick();
        }
        else
        {
            rb2d.velocity = rb2d.velocity.normalized * ballSpeed;
        }
    }

    private void LaunchOnMouseClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            rb2d.velocity = startingVelocity.normalized * ballSpeed;
            hasStarted = true;
        }
    }

    private void LockBallToPad()
    {
        Vector2 padPos = new Vector2(pad.transform.position.x, pad.transform.position.y);
        transform.position = padPos + padToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(Random.Range(0f, randomFactor), Random.Range(0f, randomFactor));
        if (hasStarted)
        {
            AudioClip clip = bounceSounds[Random.Range(0, bounceSounds.Length)];
            audioSource.PlayOneShot(clip);
            rb2d.velocity += velocityTweak;
        }
    }
}
