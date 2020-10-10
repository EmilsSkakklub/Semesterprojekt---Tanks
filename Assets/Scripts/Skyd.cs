using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skyd : MonoBehaviour
{
    public GameObject projectile;
    public float movementspeed = 250f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameObject bullet = Instantiate(projectile, transform.position, gameObject.transform.rotation) as GameObject;

            bullet.GetComponent<Rigidbody2D>().AddForce(transform.forward * movementspeed);  

        }
    }
}
