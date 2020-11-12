using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityChange : MonoBehaviour
{

    public bool reverseGravity = false;
    public float gravitySpeed = 25;


    private void Update()
    {
        if (reverseGravity == true && Input.GetKeyDown(KeyCode.G))
        {
            reverseGravity = false;
        }
        else if (reverseGravity == false && Input.GetKeyDown(KeyCode.G))
        {
            reverseGravity = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (reverseGravity == false)
        {
            Physics2D.gravity = new Vector2(0, -gravitySpeed);
        }
        else if (reverseGravity == true)
        {
            Physics2D.gravity = new Vector2(0, gravitySpeed);
        }
    }

}
