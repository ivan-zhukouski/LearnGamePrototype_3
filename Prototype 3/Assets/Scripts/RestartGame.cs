using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
   bool gameHasEnded = false;
   public void EndGame()
   {
       if(gameHasEnded == false)
       {
           gameHasEnded = true;
           Invoke("Restart", 1f);
       }
   }
    public void Restart()
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
      TimeScript.timeValue = 0;
    }

}