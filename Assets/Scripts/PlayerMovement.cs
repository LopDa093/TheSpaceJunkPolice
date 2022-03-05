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

    // Start is called before the first frame update
    void Start()
    {
        rbody2d = GetComponent<Rigidbody2D>();
        origGravityScale = rbody2d.gravityScale;
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

            rbody2d.AddForce(new Vector2(h+0.01f, v+0.01f));
        }
    }

    private void OnTriggerEnter2D(Collider2D col) {
        {
            if (col.gameObject.tag == zeroGravTag) {
                inZeroGravityZone = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col) {
        {
            if (col.gameObject.tag == zeroGravTag) {
                inZeroGravityZone = false;
            }
        }
    }
}
