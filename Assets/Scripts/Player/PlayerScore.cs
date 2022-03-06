using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public int score = 0;
    public int lives;
    public GameObject HP1, HP2, HP3, Canvas;

    // Start is called before the first frame update
    void Start()
    {
        lives = 3;    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col) {
        
    }

    public void GetDamaged()
    {
        
        lives--;
        Debug.Log("LIVES: " + lives);
        if (lives == 2)
        {
            HP3.SetActive(false);
        }
        if (lives == 1)
        {
            HP2.SetActive(false);
            Canvas.SetActive(true);
        }

        if (lives == 0)
        {
            HP1.SetActive(false);
            Time.timeScale = 0;

        }
    }
}
