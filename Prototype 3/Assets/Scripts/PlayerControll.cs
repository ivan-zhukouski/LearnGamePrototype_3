using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody playerRB;
    private Animator playerAnim;
    private AudioSource playerSound;

    public float jumpForce = 500f;
    public static float gravitiModifire = 1.5f;


    public bool isOnGround = true;
    public bool isGameOver = false;


    private static float nextJump = 0.0f;
    public static float jump = 0.2f;
    public static float doubleJumpInterval = 0.4f;

    private SpawnManager spawnManagerScript;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public ParticleSystem jumpParticle;
    public ParticleSystem withGroundParticle;

    public AudioClip jumpSound;
    public AudioClip crashSound;
    public AudioClip collisionWithGround;
     
    

    void Awake() 
    {
        Physics.gravity = new Vector3(0, -9.8f, 0);
        Physics.gravity *= gravitiModifire;
    }
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        spawnManagerScript = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        playerAnim = GetComponent<Animator>();
        dirtParticle.Play();
        playerSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && Time.time > nextJump && !isGameOver)
        {
            nextJump = Time.time + jump;
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            Invoke("DoubleJump", doubleJumpInterval);
            playerAnim.SetTrigger("Jump_trig");
            jumpParticle.Play();
            dirtParticle.Stop();
            playerSound.PlayOneShot(jumpSound,1.0f);
        }
        if( isGameOver == true)
                {
                    if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)){
                        FindObjectOfType<RestartGame>().EndGame();
                    }
                    
                }
    }
    private void OnCollisionEnter(Collision collision) 
    {
        if(collision.gameObject.CompareTag("Ground") && !isGameOver)
        {
            isOnGround = true;
            dirtParticle.Play();
            withGroundParticle.Play();
            playerSound.PlayOneShot(collisionWithGround, 1.0f);

        }
        else if(collision.gameObject.CompareTag("Obstacle"))
        {
            isGameOver = true;
            
            Debug.Log("Game Over");
            spawnManagerScript.isStopSpawn = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int",1);
            explosionParticle.Play();
    
            dirtParticle.Stop();
            playerSound.PlayOneShot(crashSound,1.0f);
            FindObjectOfType<GameOverManager>().GameOver();
            FindObjectOfType<PressEnter>().EnterToStart();
        }
        
    }  
    void DoubleJump(){
        isOnGround = false;
        //playerAnim.SetBool("Jump_trig", false );

    }
}
