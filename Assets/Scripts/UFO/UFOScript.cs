using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOScript : MonoBehaviour
{
    private float moveSpeed, timer;
    private bool moveRight, enter, exit;
    private Vector2 screenBoundsTopRight, screenBoundsTopLeft;
    public AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 2f;
        enter = true;
        timer = 10f;
        moveRight = false;
        screenBoundsTopRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        screenBoundsTopLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0));
        transform.position = new Vector2((screenBoundsTopRight.x + screenBoundsTopLeft.x)/2, screenBoundsTopRight.y +1f);
        sound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        screenBoundsTopRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        screenBoundsTopLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0));
        if (enter)
        {
            Enter();
        }else if (!exit)
        {
            Move();

        }
        else
        {
            Exit();
        }
        

    }

    private void Enter()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime);
        if (transform.position.y < screenBoundsTopRight.y - 1)
        {
            enter = false;
            moveRight = true;
        }
    }

    private void Move()
    {
        if (transform.position.x > 7f)
        {
            moveRight = false;
        }
        else if (transform.position.x < -7f)
        {
            moveRight = true;
        }

        if (moveRight)
        {
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, screenBoundsTopRight.y-1);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, screenBoundsTopRight.y - 1);
        }

        timer -= Time.deltaTime;
        if (timer < 3)
        {
            exit = true;
        }
    }

    private void Exit()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime);
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            sound.Stop();
            Destroy(this.gameObject);
            
        }
    }
}
