using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOSpawner : MonoBehaviour
{
    public float timer;
    public GameObject UFO;
    private float CD;
    // Start is called before the first frame update
    void Start()
    {
        CD = timer;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void SpawnUFO()
    {
        GameObject a = Instantiate(UFO) as GameObject;
    }

    IEnumerator spawnWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(CD);
            SpawnUFO();
        }
    }
}
