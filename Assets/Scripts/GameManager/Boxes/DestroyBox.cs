﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBox : MonoBehaviour {

    public GameObject[] Pickups;
    public Boxspawner bs;

    public void Awake() {
        bs = GameObject.Find("GameManager").GetComponent<Boxspawner>();
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Bullet" || other.gameObject.tag == "Bomb") {
            GameObject PickupSpawn = Instantiate(Pickups[Random.Range(0, Pickups.Length)], transform.position, transform.rotation) as GameObject;
            bs.BoxCount--;
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "LaserCollider")
        {
            Debug.Log("Destroyed by laser");
        }
    }


    //Destroy box when hit by laser
    //VIRKER IKKE?????????????
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "LaserCollider")
        {

            Debug.Log("Destroyed by laser");
        }
    }


}
