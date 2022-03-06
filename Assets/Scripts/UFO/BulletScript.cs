using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Vector2 moveDirection;
    private float moveSpeed;
    public GameObject player;

    private void OnEnable()
    {
        Invoke("Destroy", 4f);
    }

    void Start()
    {
        moveSpeed = 3f;
    }

    void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, FindObjectOfType<PlayerMovement>().transform.position)>=30) {
            Destroy(this.gameObject);
        }
    }

    public void SetMoveDirection(Vector2 dir)
    {
        moveDirection = dir;
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            print("Player Hit");
            FindObjectOfType<PlayerScore>().GetDamaged();
            this.gameObject.transform.position = new Vector2(-999999,-9999999);
        }
    }


}
