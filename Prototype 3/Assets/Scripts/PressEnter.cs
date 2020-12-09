using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PressEnter : MonoBehaviour
{
    // Start is called before the first frame update
    Text pressEnterText;
    void Start()
    {
        pressEnterText = GetComponent<Text>();
    }

    // Update is called once per frame
    public void EnterToStart()
    {
        pressEnterText.text = "Press Enter to start";
    }
}
