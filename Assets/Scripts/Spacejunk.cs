using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spacejunk : MonoBehaviour
{
    public float speed = 0.0f;
    private Rigidbody2D rb;
    private Vector2 screenBoundsTopRight, screenBoundsTopLeft, screenBoundsBottomLeft, screenBoundsBottomRight;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        screenBoundsTopRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        screenBoundsTopLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0));
        screenBoundsBottomLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        screenBoundsBottomRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        


        /*if (transform.position.x < screenBoundsTopRight.x * 2) {
            Destroy(this.gameObject);
        }*/
    }
}
