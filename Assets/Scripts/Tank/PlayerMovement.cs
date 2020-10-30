using JetBrains.Annotations;
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
    public int timesJumped = 0;
    public int totalJumps = 3;          //indicates number of times the player has jumped

    public bool moving = false;         //is true while tank is moving
    public bool jump = false;           //is true when player changes direction mid-air
    public bool gravityChanged = false; //is true if gravity has changed
    public bool wallCollision = false;  //is true if tank collides with wall

    public bool timerBool = false;      //boolean for direction change
    public float timer = 0.025f;        //timer for direction 

    public bool ButtonLeftTurn = false;
    public bool ButtonRightTurn = false;
    public bool ButtonShoot = false;
    public bool ButtonJump = false;
    public bool ButtonChangeGravity = false;

    // Start is called before the first frame update
    void Start() {
        //remove gravity of the player
        Physics2D.gravity = Vector2.zero;
        
    }

    // Update is called once per frame
    void Update() {
        toggleGravity();
        commandMove();
        buttonSettings();

    }

    // FixedUpdate is called once per frame (used for physics)
    private void FixedUpdate() {
        rotate();
        move();

        
    }



    //rotate player
    private void rotate() {
        if (ButtonLeftTurn) {
            body.rotation += rotationSpeed;
        } else if (ButtonRightTurn) {
            body.rotation -= rotationSpeed;
        }
    }

    //add force to tank in direction
    private void addForceToBody() {
        body.AddRelativeForce(gravityConstant * Vector2.right * maxVelocity * Time.deltaTime, ForceMode2D.Impulse);
    }

    //toggle gravity change
    private void toggleGravity() {
        if (ButtonChangeGravity) {
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
        if (ButtonJump && !moving && !jump && (timesJumped < totalJumps)) {
            jump = true;
            moving = true;
            timesJumped = timesJumped + 1;
        }
        if (ButtonJump && moving && !jump && (timesJumped < totalJumps)) {
            jump = true;
            timesJumped = timesJumped + 1;

        }
        if (jump) {
            if (timer > 0) {
                timer -= Time.deltaTime;
                if (timer <= 0) {
                    jump = false;
                    timer = 0.025f;
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
        if (moving && timesJumped == 0) {
            body.WakeUp();
            addForceToBody();
        }

        //if player is already moving, change direction
        if (moving && jump) {
            body.Sleep();
            if (body.IsSleeping()) {
                body.WakeUp();
                if (body.IsAwake()) {
                    addForceToBody();
                }
            }
        }

        //if tank collides with wall, stop movement
        if (wallCollision) {
            jump = false;
            moving = false;
            timesJumped = 0;
            body.Sleep();
        }


    }
    private void buttonSettings() {
        if (Input.GetKey(KeyCode.A)) {
            ButtonLeftTurn = true;
        } else {
            ButtonLeftTurn = false;
        }


        if (Input.GetKey(KeyCode.D)) {
            ButtonRightTurn = true;
        } else {
            ButtonRightTurn = false;
        }


        if (Input.GetKeyDown(KeyCode.W)) {
            ButtonChangeGravity = true;
        } else {
            ButtonChangeGravity = false;
        }


        if (Input.GetKeyDown(KeyCode.C)) {
            ButtonJump = true;
        } else {
            ButtonJump = false;
        }


        if (Input.GetKey(KeyCode.V)) {
            ButtonShoot = true;
        } else {
            ButtonShoot = false;
        }

    }
}

