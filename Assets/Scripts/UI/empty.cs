using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class empty : MonoBehaviour
{
    public GameObject player,junk,asteroid;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.IgnoreCollision(junk.GetComponent<Collider2D>(), asteroid.GetComponent<Collider2D>(), false);
        if (Vector2.Distance(transform.position, player.transform.position) > 20f) {
            Destroy(this.gameObject);
        }
    }
}
