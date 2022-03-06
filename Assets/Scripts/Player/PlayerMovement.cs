using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float zerogravMoveForce = 0f;
    public float normalMoveForce = 0f;
    private float moveForce = 0f;
    private Rigidbody2D rbody2d;
    public float jumpForce = 0f;
    public bool inZeroGravityZone = false;
    private float origGravityScale = 0f;
    public string zeroGravTag = "";
    public Animator anim;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        rbody2d = GetComponent<Rigidbody2D>();
        origGravityScale = rbody2d.gravityScale;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        
        moveForce = inZeroGravityZone ? zerogravMoveForce : normalMoveForce;
        rbody2d.gravityScale = inZeroGravityZone ? 0f : origGravityScale;

        if (Input.GetKeyDown(KeyCode.Space) && !inZeroGravityZone) {
            rbody2d.AddForce(Vector2.up * jumpForce);
        }
    }

    private void FixedUpdate() {
        {
            float h = Input.GetAxisRaw("Horizontal") * moveForce;
            float v = inZeroGravityZone ? Input.GetAxisRaw("Vertical") * moveForce : 0f;
            if (h<0) {
                anim.SetBool("isLeft",true);
            }
            else {
                anim.SetBool("isLeft", false);
            }
            rbody2d.AddForce(new Vector2(h+0.01f, v+0.01f));
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        {
            if (collision.gameObject.tag == zeroGravTag) {
                inZeroGravityZone = true;
            }

            if (collision.gameObject.tag == "enemy") {
                anim.SetBool("hit",true);
               
                
            }

            if (collision.gameObject.tag == "trash") {
                anim.SetBool("catch", true);
               
                
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        {
            print(collision);
            if (collision.gameObject.tag == zeroGravTag) {
                inZeroGravityZone = false;
            }

            if (collision.gameObject.tag == "enemy") {
                anim.SetBool("hit", false);
            }

            if (collision.gameObject.tag == "trash") {
                anim.SetBool("catch", false);
            }
        }

        
    }
}
