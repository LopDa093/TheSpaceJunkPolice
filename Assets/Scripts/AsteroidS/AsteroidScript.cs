using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    private Vector2 screenBoundsTopRight, screenBoundsTopLeft, screenBoundsBottomLeft, screenBoundsBottomRight;
    public GameObject player;
    public Rigidbody2D RB;
    private float moveSpeed,rotSpeed, rotZ;
    private Vector2 dir;

    public SpriteRenderer rend;
    public Sprite[] sprites;
    // Start is called before the first frame update
    void Start()
    {
        rend.sprite = sprites[Random.Range(0, sprites.Length - 1)];
        
        moveSpeed = 0.005f;
        rotSpeed = 20f;
        Vector2 dir = player.transform.position - transform.position;
        GetComponent<Rigidbody2D>().AddForce(dir * moveSpeed);

    }

    // Update is called once per frame
    void Update()
    {

        GetComponent<Rigidbody2D>().AddForce(transform.forward * moveSpeed);
        rotZ += Time.deltaTime * rotSpeed;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
        if (Vector2.Distance(transform.position, player.transform.position) > 20f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            GameObject.FindObjectOfType<PlayerScore>().lives--;
            print("Lives :"+GameObject.FindObjectOfType<PlayerScore>().lives);
        }    
    }
}
