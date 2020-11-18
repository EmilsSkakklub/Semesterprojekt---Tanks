using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class destroyBomb : MonoBehaviour {

    public GameObject explosionSpawnPoint;
    public GameObject explosion;
    public ParticleSystem nukeParicle;


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
            Instantiate(explosion, explosionSpawnPoint.transform.position, quaternion.identity);
            Instantiate(nukeParicle, explosionSpawnPoint.transform.position, quaternion.identity);

        }
        else if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Instantiate(explosion, explosionSpawnPoint.transform.position, quaternion.identity);
            Instantiate(nukeParicle, explosionSpawnPoint.transform.position, quaternion.identity);

        }
        else if (other.gameObject.tag == "Bomb")
        {
            Destroy(gameObject);
            Instantiate(explosion, explosionSpawnPoint.transform.position, quaternion.identity);
            Instantiate(nukeParicle, explosionSpawnPoint.transform.position, quaternion.identity);
        }
    }

    }


