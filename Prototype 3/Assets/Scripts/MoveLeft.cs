using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 20f;
    private float lowerBound = -25f;
    private PlayerControll playerControlScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControlScript = GameObject.Find("Player").GetComponent<PlayerControll>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerControlScript.isGameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if(TimeScript.timeValue == 30){
            speed = 25f;
            PlayerControll.jump = 0.1f;
            PlayerControll.doubleJumpInterval = 0.2f;
        }
        if(TimeScript.timeValue == 60){
            PlayerControll.jump = 0.1f;
            PlayerControll.doubleJumpInterval = 0.2f;
            speed = 30f;
        }

        if (transform.position.y < lowerBound)
        {
            Destroy(gameObject);
        }

    }
}
