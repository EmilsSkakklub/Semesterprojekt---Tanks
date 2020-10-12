using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public Rigidbody2D body;
    public GameObject indicator1, indicator2;

    public float rotationSpeed = 5f;    //rotation speed
    public float maxVelocity = 4f;      //maximum velocity of player
    private int gravityConstant = 1;    //is eather 1 with deafult ´gravity or -1 with reversed gravity
    public int numberOfJumps = 0;       //indicates number of times the player has jumped

    public bool moving = false;         //is true while tank is moving
    public bool jump = false;           //is true when player changes direction mid-air
    public bool gravityChanged = false; //is true if gravity has changed
    public bool wallCollision = false;  //is true if tank collides with wall

    public bool timerBool = false;      //boolean for direction change
    public float timer = 0.01f;          //timer for direction 

    // Start is called before the first frame update
    void Start() {
        //remove gravity of the player
        Physics2D.gravity = Vector2.zero;
    }

    // Update is called once per frame
    void Update() {
        toggleGravity();
        commandMove();
    }

    // FixedUpdate is called once per frame (used for physics)
    private void FixedUpdate() {
        rotate();
        move();
    }



    //rotate player
    private void rotate() {
        if (Input.GetKey(KeyCode.A)) {
            body.rotation += rotationSpeed;
        } else if (Input.GetKey(KeyCode.D)) {
            body.rotation -= rotationSpeed;
        }
    }

    //add force to tank in direction
    private void addForceToBody() {
        body.AddRelativeForce(gravityConstant * Vector2.right * maxVelocity * Time.deltaTime, ForceMode2D.Impulse);
    }

    //toggle gravity change
    private void toggleGravity() {
        if (Input.GetKeyDown(KeyCode.W)) {
            gravityChanged = !gravityChanged;
        }

        if (!gravityChanged) {
            indicator1.GetComponent<Renderer>().material.color = Color.red;
            indicator2.GetComponent<Renderer>().material.color = Color.white;
            gravityConstant = 1;
        } else if (gravityChanged) {
            indicator1.GetComponent<Renderer>().material.color = Color.white;
            indicator2.GetComponent<Renderer>().material.color = Color.red;
            gravityConstant = -1;
        }
    }

    //Used for the Update()-function (to avoid the FixedUpdateU()-function)
    private void commandMove() {
        //move when pressing space
        if (Input.GetKeyDown(KeyCode.Space) && !moving) {
            moving = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) && moving && numberOfJumps == 1) {
            jump = true;

        }
        if (jump && !timerBool) {
            if (timer > 0) {
                timer -= Time.deltaTime;
                if (timer <= 0) {
                    timerBool = true;
                }
            }
        }
    }

    //Move the player
    private void move() {
        //set velocity to be constant
        body.velocity = maxVelocity * (body.velocity.normalized);

        //stop the tank if it is not moving
        if (!moving) {
            body.Sleep();
        }

        //when move is true, fly in one direction
        if (moving && numberOfJumps == 0) {
            body.WakeUp();
            addForceToBody();
            numberOfJumps = 1;
        }

        //if player is already moving, change direction
        if (moving && numberOfJumps == 1 && jump) {
            body.Sleep();
            if (body.IsSleeping()) {
                body.WakeUp();
                if (body.IsAwake()) {
                    addForceToBody();
                    if (timerBool) {
                        jump = false;
                        timerBool = false;
                        numberOfJumps = 2;
                        timer = 0.01f;
                    }
                }
            }
        }

        //if tank collides with wall, stop movement
        if (wallCollision) {
            jump = false;
            moving = false;
            numberOfJumps = 0;
            body.Sleep();
        }


    }
}

