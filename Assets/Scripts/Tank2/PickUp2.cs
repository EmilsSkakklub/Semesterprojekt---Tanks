using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp2 : MonoBehaviour {
    public PlayerMovement2 tank;

    public bool TakenBoost;

    public float SpeedUpAmount = 3;
    public float RotationSpeedUpAmount = 3f;

    public float SpeedDownAmount = 3f;
    public float RotationSpeedDownAmount = 3f;

    public float SpeedUpTime = 10;
    public float SpeedDownTime = 10;

    public float Bombs = 0;

    private float OriginalSpeed;
    private float OriginalRotationSpeed;


    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "SpeedUp" && !TakenBoost) {
            Debug.Log("UP taken");
            Invoke("IsSpeededUp", 0);
            Destroy(other.gameObject);
        } else if (other.gameObject.tag == "SpeedDown" && !TakenBoost) {
            Debug.Log("DOWN taken");
            Invoke("IsSlowedDown", 0);
            Destroy(other.gameObject);
        } else if (other.gameObject.tag == "BombUp") {

            Debug.Log("bomb aquired");
            Bombs++;
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


}
