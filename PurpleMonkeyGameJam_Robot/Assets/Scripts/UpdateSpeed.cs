using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateSpeed : MonoBehaviour
{
    public Text myText;
    public BotController myBot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (myBot != null)
        {
            myText.text = myBot.Score.ToString();
        }

    }
}
