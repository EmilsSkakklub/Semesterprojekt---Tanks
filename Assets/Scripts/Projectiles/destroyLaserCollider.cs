using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyLaserCollider : MonoBehaviour
{

    public CircleCollider2D laserColl;

    // Start is called before the first frame update
    private void Start()
    {
        gameObject.tag = "LaserCollider";
        gameObject.layer =  LayerMask.NameToLayer("Ignore Raycast");
        laserColl = laserColl.GetComponent<CircleCollider2D>();
        laserColl.isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("destroyLaserColl", 0.1f);
    }

    private void destroyLaserColl()
    {
        Destroy(gameObject);
    }
}


