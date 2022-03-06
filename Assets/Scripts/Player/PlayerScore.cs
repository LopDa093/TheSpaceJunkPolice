using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScore : MonoBehaviour
{
    public int score = 0;
    public int lives;
    public GameObject HP1, HP2, HP3, Canvas;
    public AudioSource sound1, sound2;

    // Start is called before the first frame update
    void Start()
    {
        lives = 3;    
    }

    // Update is called once per frame
    void Update()
    {
        if (lives == 2) {
            Destroy(HP3.gameObject);
        }
        if (lives == 1) {
            Destroy(HP2.gameObject);
            Canvas.SetActive(true);
        }

        if (lives == 0) {
            Destroy(HP1.gameObject);
            sound1.Stop();
            sound2.Stop();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
    }

    private void OnCollisionEnter2D(Collision2D col) {
        
    }

    public void GetDamaged()
    {
        
        lives--;
        Debug.Log("LIVES: " + lives);
        
    }
}
