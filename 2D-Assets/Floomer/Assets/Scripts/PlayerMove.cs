using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 500;
    GameObject feet;
    Camera camera;
    bool canJump = true;

    // Use this for initialization
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    private void Update()
    {

    }


    void FixedUpdate()
    {

        playerMove();
        //Vector2 cameraPos = new Vector2(camera.transform.position.x, camera.transform.position.y);
        Vector2 playerPos = new Vector2(transform.position.x, transform.position.y);
        //cameraPos = Vector2.Lerp(cameraPos, playerPos, 0.10f);
        //camera.transform.position = new Vector3(cameraPos.x, cameraPos.y, -10);
    }

    void playerMove()
    {
        float xMovement = Input.GetAxisRaw("Horizontal");
        //float yMovement = Input.GetAxisRaw("Vertical");
        float jump = Input.GetAxisRaw("Jump");

        //this handles player x movement
        if (xMovement != 0)
        {
            if (gameObject.GetComponent<Rigidbody2D>().velocity.x >= 20 || gameObject.GetComponent<Rigidbody2D>().velocity.x < -20)
            {

            }
            else
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(5 * xMovement * speed * Time.deltaTime, 0f));
            }
        }

        //stops you without if you have too much force on you. Possibly unneeded.
        else
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.Lerp(new Vector2(0f, gameObject.GetComponent<Rigidbody2D>().velocity.y), new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, gameObject.GetComponent<Rigidbody2D>().velocity.y), .90f);
        }

        //incomplete jumping scrpit. Needs to have can jump implemented with a raycast or a collider at the players feet. 
        if (canJump && jump != 0)
        {
            Debug.Log("I jumped!");
            canJump = false;
            gameObject.GetComponent<Rigidbody2D>().AddForce(500 * new Vector2(0f, 1.0f));
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "hi")
        {

        }
    }


}