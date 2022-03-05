using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deploySpacejunk : MonoBehaviour
{
    public GameObject spacejunkPrefab;
    public GameObject player;
    public float respawnTime = 1.5f;
    private Vector2 screenBoundsTopRight, screenBoundsTopLeft, screenBoundsBottomLeft, screenBoundsBottomRight;
    // Start is called before the first frame update
    void Start()
    {
        screenBoundsTopRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        screenBoundsTopLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0));
        screenBoundsBottomLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        screenBoundsBottomRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));
        StartCoroutine(spawnWave());
    }

    private void spawnEnemy(GameObject player) {
        //top
        for (int i = 0; i < 2; i++) {
            float random = Random.Range(screenBoundsTopLeft.x, screenBoundsBottomRight.x);
            GameObject a = Instantiate(spacejunkPrefab) as GameObject;
            a.transform.position = new Vector2(random, screenBoundsTopLeft.y +1f );
        }
        //bottom
        for (int i = 0; i < 2; i++) {
            float random = Random.Range(screenBoundsTopLeft.x, screenBoundsBottomRight.x);
            GameObject a = Instantiate(spacejunkPrefab) as GameObject;
            a.transform.position = new Vector2(random, screenBoundsBottomLeft.y - 1f);
        }
        //left
        for (int i = 0; i < 2; i++) {
            float random = Random.Range(screenBoundsTopLeft.y, screenBoundsBottomLeft.y);
            GameObject a = Instantiate(spacejunkPrefab) as GameObject;
            a.transform.position = new Vector2( screenBoundsTopLeft.x - 1f ,random);
        }
        //right
        for (int i = 0; i < 2; i++) {
            float random = Random.Range(screenBoundsTopLeft.y, screenBoundsBottomLeft.y);
            GameObject a = Instantiate(spacejunkPrefab) as GameObject;
            a.transform.position = new Vector2(screenBoundsTopRight.x + 1f, random);
        }
    }

    IEnumerator spawnWave() {
        while (true) {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy(player);
        }
    }

    // Update is called once per frame
    void Update()
    {
        screenBoundsTopRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        screenBoundsTopLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0));
        screenBoundsBottomLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        screenBoundsBottomRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));
    }
}
