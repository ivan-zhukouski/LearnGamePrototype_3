using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver;
    private bool isOnGround = false;
    private bool isLowEnough = true;

    public float floatForce = 700f;
    private float floatForceWithGround = 450f;
    private float  floatForceWithCeiling = 20f;
    private float gravityModifier = 1.5f;
    private float jump = 0.4f;
    private float nextJump = 0.0f;
    private float boundY = 14.34f;
    private float speed = 15f;
    private Rigidbody playerRb;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;
    public AudioClip jumpSound;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();

        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        // While space is pressed and player is low enough, float up
        if (Input.GetKey(KeyCode.Space) && !gameOver && Time.time > nextJump && isLowEnough)
        {
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            nextJump = Time.time + jump;
            playerRb.AddForce(Vector3.up * floatForce);
        }
        if(transform.position.y > boundY){
            isLowEnough = false;
            //playerRb.AddForce(Vector3.down * floatForceWithCeiling);
        }
        if(transform.position.y < boundY)
        {
            isLowEnough = true;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        } 

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);

        }
        else if (other.gameObject.CompareTag("Ground") && !gameOver)
        {
            //Vector3 newPos = new Vector3(transform.position.x, posY, transform.position.z);
            //transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * speed);
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            playerRb.AddForce(Vector3.up * floatForceWithGround);
        }

    }

}
