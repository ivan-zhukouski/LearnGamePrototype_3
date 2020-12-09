using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour
{
    // Start is called before the first frame update
    public static int timeValue = 0;
    private PlayerControll playerControllScript;

    Text gameDuration;

    void Start()
    {
        InvokeRepeating("TimeScore", 0.0f,1f);
        gameDuration = GetComponent<Text>();
        playerControllScript = GameObject.Find("Player").GetComponent<PlayerControll>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerControllScript.isGameOver == false)
        {
             gameDuration.text = "Time: " + timeValue;
        }
         if(playerControllScript.isGameOver == true)
         {
             gameDuration.text = "";
         }
       
         
    }
    public void TimeScore()
    {
        if(playerControllScript.isGameOver == false)
         {
            timeValue += 1;
         }
        
       
    }
}
