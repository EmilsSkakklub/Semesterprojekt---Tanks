using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D tankBody;
    public GameObject dirIndicator1, dirIndicator2;

    //Attributes for movement
    public float rotationSpeed = 5f;
    public float speed = 100;
    public float maxVelocity = 5f;
    
    //attributes for gravity and collision detection
    private float gravityConstant = 1;
    public bool gravityChanged = false;
    public bool hitWall = false;
    public bool jump = false;


    private void Start()
    {
        Physics2D.gravity = Vector2.zero;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        rotate();
        move();
    }


    private void Update()
    {
        playerJump();
        changeGravity();
    }

    //player rotation
    private void rotate()
    {

        if (Input.GetKey(KeyCode.A))
        {
            tankBody.rotation += rotationSpeed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            tankBody.rotation -= rotationSpeed;
        }
    }

    //toggle gravity change
    private void changeGravity()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            gravityChanged = !gravityChanged;
        }

        if (!gravityChanged)
        {
            dirIndicator1.GetComponent<Renderer>().material.color = Color.red;
            dirIndicator2.GetComponent<Renderer>().material.color = Color.white;
            gravityConstant = 1f;
        }
        else if(gravityChanged)
        {
            dirIndicator1.GetComponent<Renderer>().material.color = Color.white;
            dirIndicator2.GetComponent<Renderer>().material.color = Color.red;
            gravityConstant = -1f;
        }
    }

    //press space to jump
    private void playerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !jump)
        {
            jump = true;
        }
    }

    //sets player velocity to 0
    private void stopPlayer()
    {
        tankBody.velocity = Vector2.zero;
        tankBody.angularVelocity = 0;
    }

    //set maximum velocity
    private void maximumVelocity()
    {

        if (tankBody.velocity.x >= maxVelocity)
        {
            tankBody.velocity = new Vector2(maxVelocity, tankBody.velocity.y);
        }
        if (tankBody.velocity.x <= -maxVelocity)
        {
            tankBody.velocity = new Vector2(-maxVelocity, tankBody.velocity.y);
        }
        if (tankBody.velocity.y >= maxVelocity)
        {
            tankBody.velocity = new Vector2(tankBody.velocity.x, -maxVelocity);
        }
        if (tankBody.velocity.y <= -maxVelocity)
        {
            tankBody.velocity = new Vector2(tankBody.velocity.x, maxVelocity);
        }
    }



    //Move the player in direction
    private void move() 
    {
        maximumVelocity();

        if (jump)
        {
            jump = false;
            tankBody.AddRelativeForce(gravityConstant * Vector2.right * speed, ForceMode2D.Impulse);
        }

        if(jump && !hitWall)
        {
            jump = false;
            Invoke("stopPlayer", 0);
            tankBody.AddRelativeForce(gravityConstant * Vector2.right * speed, ForceMode2D.Impulse);
        }


        if(hitWall)
        {
            Invoke("stopPlayer", 0);
            Invoke("move",0.5f);
        }
    }


}

