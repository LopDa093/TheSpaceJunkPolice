using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    
    public GameObject star;
    public Sprite[] sprites;
    public float respawnTime = 1.5f;
    private Vector2 screenBoundsTopRight, 
        screenBoundsTopLeft,
        screenBoundsBottomLeft, 
        screenBoundsBottomRight;

    // Start is called before the first frame update
    void Start()
    {
        //rend.sprite = sprites[Random.Range(0, sprites.Length - 1)];
        screenBoundsTopRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, -1));
        screenBoundsTopLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, -1));
        screenBoundsBottomLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, -1));
        screenBoundsBottomRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, -1));
        StartCoroutine(spawnWave());
    }

    IEnumerator spawnWave() {
        while (true) {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
        }
    }

    private void spawnEnemy() {
        
    
            for (int i = 0; i < 1; i++) {
                float random = Random.Range(screenBoundsTopLeft.x, screenBoundsBottomRight.x);
                GameObject a = Instantiate(star) as GameObject;
                Debug.Log(a.GetComponent<SpriteRenderer>());
                a.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length - 1)];
                a.transform.localScale = new Vector3(0.1f,0.1f,0.1f);
                a.transform.position = new Vector2(random, screenBoundsTopLeft.y + 1f);
                //extra.SetValue(a, index);
               
            }
      

        //bottom
       
            for (int i = 0; i < 1; i++) {
                float random = Random.Range(screenBoundsTopLeft.x, screenBoundsBottomRight.x);
                GameObject a = Instantiate(star) as GameObject;
            a.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length - 1)];
            a.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            a.transform.position = new Vector2(random, screenBoundsBottomLeft.y - 1f);
                //extra.SetValue(a, index);
             
            }
       

        //left
        
            for (int i = 0; i < 1; i++) {
                float random = Random.Range(screenBoundsTopLeft.y, screenBoundsBottomLeft.y);
                GameObject a = Instantiate(star) as GameObject;
                a.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length - 1)];
            a.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            a.transform.position = new Vector2(screenBoundsTopLeft.x - 1f, random);
                //extra.SetValue(a, index);
              
            }
       

        //right
    
            for (int i = 0; i < 1; i++) {
                float random = Random.Range(screenBoundsTopLeft.y, screenBoundsBottomLeft.y);
                GameObject a = Instantiate(star) as GameObject;
                a.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length - 1)];
            a.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            a.transform.position = new Vector2(screenBoundsTopRight.x + 1f, random);
                //extra.SetValue(a, index);
                
            }
        
    }
    // Update is called once per frame
    void Update()
    {
        screenBoundsTopRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, -1));
        screenBoundsTopLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, -1));
        screenBoundsBottomLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, -1));
        screenBoundsBottomRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, -1));
    }
}
