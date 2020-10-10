using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Rigidbody2D rigidbodyTank;

    public bool TakenBoost;

    public float SpeedUpAmount = 3;
    public float SpeedUpTime = 10;

    public float SpeedDownAmount = 0.5f;
    public float SpeedDownTime = 10;

    private float OriginalMass;


    private void OnTriggerEnter2D(Collider2D other)
    
    {
        if (other.gameObject.tag == "SpeedUp" && !TakenBoost)
        {
                Debug.Log("UP taken");
                Invoke("IsSpeededUp",0);
                Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "SpeedDown" && !TakenBoost)
        {
                Debug.Log("DOWN taken");
                Invoke("IsSlowedDown", 0);
                Destroy(other.gameObject);
        }

    }
    private void IsSpeededUp()
    {
        OriginalMass = rigidbodyTank.mass;
        rigidbodyTank.mass = rigidbodyTank.mass - SpeedUpAmount;
        Invoke("IsNormal", SpeedUpTime);
        TakenBoost = true;
        
    }
    private void IsSlowedDown()
    {
        OriginalMass = rigidbodyTank.mass;
        rigidbodyTank.mass = rigidbodyTank.mass + SpeedDownAmount;
        Invoke("IsNormal", SpeedDownTime);
        TakenBoost = true;
    }
    private void IsNormal()
    {
        rigidbodyTank.mass = OriginalMass;
        TakenBoost = false;
    }

    
}
