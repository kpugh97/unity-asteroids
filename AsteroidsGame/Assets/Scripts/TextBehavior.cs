using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBehavior : MonoBehaviour
{
    [SerializeField]
    private GameObject text;

    private Text scoreText;

    public int scoreNum = 0;


    // Start is called before the first frame update
    void Start()
    {
        //initialize the text
        scoreText = text.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //set score to be 0 in the game
        scoreText.text = "Score " + scoreNum.ToString();
    }
}
