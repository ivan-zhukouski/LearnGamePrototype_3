using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{ 
    Text gameOverValue;
    
    void Start()
    {
        gameOverValue = GetComponent<Text>();
    }
    public void GameOver()
    {
        gameOverValue.text = "Game Over \nYour time is " + TimeScript.timeValue + " sec!";
    }
}
