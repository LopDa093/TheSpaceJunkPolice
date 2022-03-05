using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deploySpacejunk : MonoBehaviour
{
    public GameObject spacejunkPrefab;
    public float respawnTime = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void spawnEnemy() {
        GameObject a = Instantiate(spacejunkPrefab) as GameObject;
        a.transform.position = new Vector2();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
