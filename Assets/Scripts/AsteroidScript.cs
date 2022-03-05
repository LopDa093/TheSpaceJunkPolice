using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 dir = player.transform.position - transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
