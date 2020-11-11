using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp2 : MonoBehaviour {
    public PlayerMovement2 tank;

    public bool TakenBoost;                     //is true if a certain boost has been picked up

    public float SpeedUpAmount = 3f;             //amount the players velocity speeds up when picking up 'speed up'
    public float RotationSpeedUpAmount = 3f;    //amount the players rotation speeds up when picking up 'speed up'

    public float SpeedDownAmount = 3f;          //amount the players velocity speeds dpwn when picking up 'speed down'
    public float RotationSpeedDownAmount = 3f;  //amount the players rotation speeds down when picking up 'speed down'

    public float SpeedUpTime = 10f;             //timer for speed up pick up
    public float SpeedDownTime = 10f;           //timer for speed down pick up
    public float BurstTime = 10f;               //timer for burst pick up

    public int Bombs = 0;                       //indicates number of nukes a player has

    public bool burstFire = false;              //if true, player shoots a burst of bullets when firing
    public bool shotgunFire = false;
    public bool laserFire = false;

    private float OriginalSpeed;                //the original velocity of the player
    private float OriginalRotationSpeed;        //the original rotation speed of the player

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "SpeedUp" && !TakenBoost) {
            Debug.Log("UP taken");
            Invoke("IsSpeededUp", 0);
            Destroy(other.gameObject);
        } 
        else if (other.gameObject.tag == "SpeedDown" && !TakenBoost) {
            Debug.Log("DOWN taken");
            Invoke("IsSlowedDown", 0);
            Destroy(other.gameObject);
        } 
        else if (other.gameObject.tag == "BombUp") {

            Debug.Log("bomb aquired");
            Bombs++;
            Destroy(other.gameObject);
        } 
        else if (other.gameObject.tag == "Burst") {
            Debug.Log("Burst aquired");
            Burst();
            Destroy(other.gameObject);
        } else if (other.gameObject.tag == "Shotgun") {
            Debug.Log("Shotgun aquired");
            Shotgun();
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Laser")
        {
            Debug.Log("Laser aquired");
            Laser();
            Destroy(other.gameObject);
        }

    }
    private void IsSpeededUp() {
        OriginalSpeed = tank.maxVelocity;
        OriginalRotationSpeed = tank.rotationSpeed;
        tank.maxVelocity = tank.maxVelocity + SpeedUpAmount;
        tank.rotationSpeed = tank.rotationSpeed + RotationSpeedUpAmount;
        Invoke("IsNormal", SpeedUpTime);
        TakenBoost = true;

    }
    private void IsSlowedDown() {
        OriginalSpeed = tank.maxVelocity;
        OriginalRotationSpeed = tank.rotationSpeed;
        tank.maxVelocity = tank.maxVelocity - SpeedDownAmount;
        tank.rotationSpeed = tank.rotationSpeed - RotationSpeedUpAmount;
        Invoke("IsNormal", SpeedDownTime);
        TakenBoost = true;
    }
    private void IsNormal() {
        tank.maxVelocity = OriginalSpeed;
        tank.rotationSpeed = OriginalRotationSpeed;
        TakenBoost = false;
    }
    private void Burst() {
        burstFire = true;
        Invoke("ShootNormal", BurstTime);
    }
    private void ShootNormal() {
        burstFire = false;
    }
    private void Shotgun() {
        shotgunFire = true;
    }

    private void Laser()
    {
        laserFire = true;
    }

}
