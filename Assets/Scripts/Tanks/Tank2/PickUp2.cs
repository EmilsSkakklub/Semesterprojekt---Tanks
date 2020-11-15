using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp2 : MonoBehaviour {
    public PlayerMovement2 tank;

    public BluePickUpTimer but;
    public GameObject blueProcessBar;
    public GameObject canon;

    public bool TakenBoost;                     //is true if a certain boost has been picked up

    public float SpeedUpAmount = 3f;             //amount the players velocity speeds up when picking up 'speed up'
    public float RotationSpeedUpAmount = 3f;    //amount the players rotation speeds up when picking up 'speed up'

    public float SpeedDownAmount = 3f;          //amount the players velocity speeds dpwn when picking up 'speed down'
    public float RotationSpeedDownAmount = 3f;  //amount the players rotation speeds down when picking up 'speed down'

    public float SpeedUpTime = 10f;             //timer for speed up pick up
    public float SpeedDownTime = 10f;           //timer for speed down pick up
    public float BurstTime = 10f;               //timer for burst pick up
    public float LaserTime = 10f;               //timer for laser pick up

    public bool startShootNormalCooldown = false;

    public bool bomb = false;
    public bool burstFire = false;              //if true, player shoots a burst of bullets when firing
    public bool laserFire = false;
    public bool flameFire = false;

    private float OriginalSpeed;                //the original velocity of the player
    private float OriginalRotationSpeed;        //the original rotation speed of the player

    private float lerp = 0;


    private void Start()
    {
        but = GameObject.Find("HealthBarBlue").GetComponentInChildren<BluePickUpTimer>();
        blueProcessBar = GameObject.Find("BlueProcessBar");
        canon = GameObject.Find("Canon2");
    }

    private void Update()
    {
        delayCooldown();
        ShowPickUpTimer();
    }


    private void ShowPickUpTimer()
    {
        blueProcessBar.SetActive(false);

        if (burstFire)
        {
            blueProcessBar.SetActive(true);
            but.updateSliderValue(BurstTime);
        }
        else if (laserFire)
        {
            blueProcessBar.SetActive(true);
            but.updateSliderValue(LaserTime);
        }
        else if (bomb)
        {
            lerp += Time.deltaTime;
            if (lerp >= 1)
            {
                lerp = 0;
            }
            canon.GetComponent<Renderer>().material.color = Color.LerpUnclamped(Color.black, Color.red, lerp);
        }
        else
        {
            canon.GetComponent<Renderer>().material.color = new Color32(49, 53, 50, 255);
            blueProcessBar.SetActive(false); ;
        }
    }


    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "BombUp" && !TakenBoost) {

            Debug.Log("bomb aquired");
            Bomb();
            Destroy(other.gameObject);
        } 
        else if (other.gameObject.tag == "Burst" && !TakenBoost) {
            Debug.Log("Burst aquired");
            Burst();
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Laser" && !TakenBoost)
        {
            Debug.Log("Laser aquired");
            Laser();
            Destroy(other.gameObject);
        }
        else if(other.gameObject.tag == "FlameThrower" && !TakenBoost)
        {
            Debug.Log("Flame Thrower");
            FlameThrower();
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
    

    private void ShootNormal() {
        startShootNormalCooldown = false;
        TakenBoost = false;
        bomb = false;
        burstFire = false;
        laserFire = false;
        flameFire = false;
    }
    private void Bomb()
    {
        bomb = true;
        TakenBoost = true;
    }

    private void Burst() {
        burstFire = true;
        TakenBoost = true;
    }


    private void Laser()
    {
        laserFire = true;
        TakenBoost = true;
    }


    private void FlameThrower()
    {
        flameFire = true;
        TakenBoost = true;
    }


    private void delayCooldown()
    {
        if (burstFire)
        {
            if (tank.ButtonShoot)
            {
                startShootNormalCooldown = true;
            }
            if (startShootNormalCooldown)
            {
                BurstTime -= Time.deltaTime;
                if (BurstTime <= 0)
                {
                    ShootNormal();
                    BurstTime = 10f;
                }
            }
        }

        if (laserFire)
        {
            if (tank.ButtonShoot)
            {
                LaserTime -= Time.deltaTime;
                if (LaserTime <= 0)
                {
                    ShootNormal();
                    LaserTime = 10f;
                }
            }
        }
        if (bomb)
        {
            if (tank.ButtonShoot)
            {
                ShootNormal();
            }
        }
    }


}
