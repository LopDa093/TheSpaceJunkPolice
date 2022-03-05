using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spacejunk : MonoBehaviour
{
    public float speed = 0.0f;
    public GameObject player;
    private Rigidbody2D rb;
    private Vector2 screenBoundsTopRight, screenBoundsTopLeft, screenBoundsBottomLeft, screenBoundsBottomRight;
    public string Tag = "";
    public SpriteRenderer rend;
    public Sprite[] sprites;
    
    // Start is called before the first frame update
    void Start()
    {
        rend.sprite = sprites[Random.Range(0, sprites.Length-1)];
        rb = this.GetComponent<Rigidbody2D>();
        screenBoundsTopRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        screenBoundsTopLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0));
        screenBoundsBottomLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        screenBoundsBottomRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {

        if (Vector2.Distance(transform.position, player.transform.position) >= 10) {
            Destroy(this);
        }

        /*if (transform.position.x < screenBoundsTopRight.x * 2) {
            Destroy(this.gameObject);
        }*/
    }

    private void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == Tag) {
            
        }
    }
}
