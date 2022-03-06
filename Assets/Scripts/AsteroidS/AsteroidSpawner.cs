using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{

    public GameObject asteroidPrefab;
    private Vector2 screenBoundsTopRight, screenBoundsTopLeft, screenBoundsBottomLeft, screenBoundsBottomRight;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        screenBoundsTopRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, -1));
        screenBoundsTopLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, -1));
        screenBoundsBottomLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, -1));
        screenBoundsBottomRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, -1));
        StartCoroutine(spawnWave());
    }

    // Update is called once per frame
    void Update()
    {
        screenBoundsTopRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, -1));
        screenBoundsTopLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, -1));
        screenBoundsBottomLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, -1));
        screenBoundsBottomRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, -1));
    }

    private void spawnEnemy() {
        int index = Random.Range(0,3);
        print(index);
        //top
        if (index == 0) {
                float random = Random.Range(screenBoundsTopLeft.x, screenBoundsBottomRight.x);
                GameObject a = Instantiate(asteroidPrefab) as GameObject;
                a.transform.position = new Vector2(random, screenBoundsTopLeft.y + 1f);
            //extra.SetValue(a, index);
            
            
        }
            
        //bottom
        if (index == 1) {
                float random = Random.Range(screenBoundsTopLeft.x, screenBoundsBottomRight.x);
                GameObject a = Instantiate(asteroidPrefab) as GameObject;
                a.transform.position = new Vector2(random, screenBoundsBottomLeft.y - 1f);
            //extra.SetValue(a, index);
            
        
        }
        
        //left
        if (index == 2) {

                float random = Random.Range(screenBoundsTopLeft.y, screenBoundsBottomLeft.y);
                GameObject a = Instantiate(asteroidPrefab) as GameObject;
                a.transform.position = new Vector2(screenBoundsTopLeft.x - 1f, random);
            //extra.SetValue(a, index);
            
        
        }
        
        //right
        if (index == 3) {

                float random = Random.Range(screenBoundsTopLeft.y, screenBoundsBottomLeft.y);
                GameObject a = Instantiate(asteroidPrefab) as GameObject;
                a.transform.position = new Vector2(screenBoundsTopRight.x + 1f, random);
            //extra.SetValue(a, index);
            
        
        }
    }
    IEnumerator spawnWave() {
        while (true) {
            yield return new WaitForSeconds(timer);
            spawnEnemy();
        }
    }
}
