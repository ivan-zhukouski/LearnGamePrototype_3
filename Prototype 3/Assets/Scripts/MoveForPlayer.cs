using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForPlayer : MonoBehaviour
{
    private float speed = 10f;
    private float xPos = -40f;
    private Animator playerAnim;

    // Start is called before the first frame update
    void Start()
    {
       playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < xPos)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        
        }
       
    }

}
