using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyBullet : MonoBehaviour
{

    public Rigidbody2D bullet;

    public int numberOfBounces = 3;     //amount of times the bullet can bounce of walls before being destroyed
    public bool disableObject = false;  //disables object after hitting wall a number of times

    private Vector2 lastVelocity;       //save the velocity of the bullet

    private void Start()
    {
        bullet = bullet.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        lastVelocity = bullet.velocity;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            bullet.velocity = Vector3.Reflect(lastVelocity, other.contacts[0].normal);
            transform.right = Vector3.Reflect(transform.right, other.contacts[0].normal);
            numberOfBounces--;

            //after a certain number of bounces, destroy bullet
            if (numberOfBounces <= 0)
            {
                removeBullet();
            }

        }
        else if (other.gameObject.tag == "Player")
        {
            removeBullet();
        }
        else if (other.gameObject.tag == "Bullet")
        {
            removeBullet();
        }
        else if (other.gameObject.tag == "Bomb")
        {
            removeBullet();
        }
    }

    private void destroyObject()
    {
        Destroy(gameObject);
    }

    private void removeBullet()
    { 
        disableObject = true;
        bullet.Sleep();
        Invoke("destroyObject", 2f);
    }

}
