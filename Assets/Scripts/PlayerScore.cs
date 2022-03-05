using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public int score = 0;
    public int lives = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == Tag) {
            Destroy(this.gameObject);
            this.gameObject.SetActive(false);
            GameObject.FindObjectOfType<deploySpacejunk>().index--;
            GameObject.FindObjectOfType<PlayerScore>().score++;
            Debug.Log(GameObject.FindObjectOfType<PlayerScore>().score);
        }
    }
}
