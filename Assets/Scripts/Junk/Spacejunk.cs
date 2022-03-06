using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spacejunk : MonoBehaviour
{
    public float speed = 0.0f;
    public GameObject player, deploy;
    private Rigidbody2D rb;
    private Vector2 screenBoundsTopRight, screenBoundsTopLeft, screenBoundsBottomLeft, screenBoundsBottomRight;
    public AudioSource sound, sound1;
    public string Tag = "Player";
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
        player = GameObject.FindGameObjectWithTag("Player");
        //Debug.Log(GameObject.FindObjectOfType<deploySpacejunk>().index);
        if ((Mathf.Abs(player.transform.position.x) - Mathf.Abs(transform.position.x)) <= -10  || 
            (Mathf.Abs(player.transform.position.y) - Mathf.Abs(transform.position.y)) <= -10  ||
            (Mathf.Abs(player.transform.position.x) - Mathf.Abs(transform.position.x)) >= 10 ||
            (Mathf.Abs(player.transform.position.y) - Mathf.Abs(transform.position.y)) >= 10) {
            Destroy(this.gameObject);
            this.gameObject.SetActive(false); 
            GameObject.FindObjectOfType<deploySpacejunk>().index--;
        }

        
    }

    private void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == Tag) {
            sound.Play();
            sound1.Play();
            Destroy(this.gameObject);
            this.gameObject.SetActive(false);
            GameObject.FindObjectOfType<deploySpacejunk>().index--;
            GameObject.FindObjectOfType<PlayerScore>().score++;
            print(GameObject.FindObjectOfType<PlayerScore>().score);
            Debug.Log(GameObject.FindObjectOfType<PlayerScore>().score);
        }
    }
}
