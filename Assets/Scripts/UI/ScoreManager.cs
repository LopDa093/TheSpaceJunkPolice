using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
   

    public GameObject player;

    int score=0;
   

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString() + " POINTS";
     
    }

    // Update is called once per frame
    void Update()
    {

        score = GameObject.FindObjectOfType<PlayerScore>().score;
        print(score);
        scoreText.text = score.ToString() + " POINTS";
    
    }
}
