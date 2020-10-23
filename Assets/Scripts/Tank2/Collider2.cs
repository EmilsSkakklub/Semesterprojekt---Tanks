using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider2 : MonoBehaviour {

    public float timer = 0.025f;
    public PlayerMovement2 pm;



    //check if tank has contact with wall
    private void OnCollisionStay2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Wall")) {
            if (timer > 0) {
                pm.wallCollision = true;
                timer -= Time.deltaTime;
                if (timer <= 0) {
                    pm.wallCollision = false;
                }
            }
        }
    }

    //Check if player no longer has collision with ground
    void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Wall")) {
            timer = 0.025f;
            pm.wallCollision = false;
        }
    }

}
