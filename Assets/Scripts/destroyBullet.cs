using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyBullet : MonoBehaviour {
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Wall") {
            Destroy(gameObject);
        }
    }



}

