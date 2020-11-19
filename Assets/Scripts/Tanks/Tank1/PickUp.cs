using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour{
    public PlayerMovement tank;

    private PinkPickUpTimer put;
    private GameObject pinkProcessBar;
    private GameObject canon;


    public bool TakenBoost;                     //is true if a certain boost has been picked up

    public float SpeedUpAmount = 3f;             //amount the players velocity speeds up when picking up 'speed up'
    public float RotationSpeedUpAmount = 3f;    //amount the players rotation speeds up when picking up 'speed up'

    public float SpeedDownAmount = 3f;          //amount the players velocity speeds dpwn when picking up 'speed down'
    public float RotationSpeedDownAmount = 3f;  //amount the players rotation speeds down when picking up 'speed down'

    public float SpeedUpTime = 10f;             //timer for speed up pick up
    public float SpeedDownTime = 10f;           //timer for speed down pick up
    public float BurstTime = 10f;               //timer for burst pick up
    public float LaserTime = 10f;               //timer for laser pick up
    public float FlameTimer = 10f;               //timer for the flame thrower pick up

    public bool startShootNormalCooldown = false;

    public bool bomb = false;
    public bool burstFire = false;              //if true, player shoots a burst of bullets when firing
    public bool laserFire = false;
    public bool flameFire = false;
    public bool homingFire = false;

    private float OriginalSpeed;                //the original velocity of the player
    private float OriginalRotationSpeed;        //the original rotation speed of the player

    private float lerp = 0;


    private void Start()
    {
        put = GameObject.Find("HealthBarPink").GetComponentInChildren<PinkPickUpTimer>();
        pinkProcessBar = GameObject.Find("PinkProcessBar");
        canon = GameObject.Find("Canon1");
    }


    private void Update()
    {
        delayCooldown();
        ShowPickUpTimer();
    }


    //activate process bar which shows how much more ammo a certain pick up has left
    private void ShowPickUpTimer()
    {
        pinkProcessBar.SetActive(false);

        if (burstFire)
        {
            pinkProcessBar.SetActive(true);
            put.updateSliderValue(BurstTime);
        }
        else if (laserFire)
        {
            pinkProcessBar.SetActive(true);
            put.updateSliderValue(LaserTime);
        }
        else if (bomb)
        {
            lerp += Time.deltaTime;
            if(lerp >= 1)
            {
                lerp = 0;
            }
            canon.GetComponent<Renderer>().material.color = Color.LerpUnclamped(Color.black, Color.red, lerp);
        }
        else if (flameFire)
        {
            pinkProcessBar.SetActive(true);
            put.updateSliderValue(FlameTimer);
        }
        else if (homingFire)
        {
            
        }

        else
        {
            canon.GetComponent<Renderer>().material.color = new Color32(49, 53, 50, 255);
            pinkProcessBar.SetActive(false);
        }
    }

    


    private void OnTriggerEnter2D(Collider2D other)
    { 
        if (other.gameObject.tag == "BombUp" && !TakenBoost) {

            Debug.Log("Bomb aquired");
            Bomb();
            Destroy(other.gameObject);
        }
        else if(other.gameObject.tag == "Burst" && !TakenBoost)
        {
            Debug.Log("Burst aquired");
            Burst();
            Destroy(other.gameObject);
        }
        else if(other.gameObject.tag == "Laser" && !TakenBoost)
        {
            Debug.Log("Laser aquired");
            Laser();
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "FlamePickUp" && !TakenBoost)
        {
            Debug.Log("Flame Thrower");
            FlameThrower();
            Destroy(other.gameObject);
        }
        else if(other.gameObject.tag == "HomingMissile" && !TakenBoost)
        {
            Debug.Log("Homing Missile");
            HomingMissile();
            Destroy(other.gameObject);
        }
    }

    private void IsSpeededUp()
    {
        OriginalSpeed = tank.maxVelocity;
        OriginalRotationSpeed = tank.rotationSpeed;
        tank.maxVelocity = tank.maxVelocity + SpeedUpAmount;
        tank.rotationSpeed = tank.rotationSpeed + RotationSpeedUpAmount;
        Invoke("IsNormal", SpeedUpTime);
        TakenBoost = true;
        
    }
    private void IsSlowedDown()
    {
        OriginalSpeed = tank.maxVelocity;
        OriginalRotationSpeed = tank.rotationSpeed;
        tank.maxVelocity = tank.maxVelocity - SpeedDownAmount;
        tank.rotationSpeed = tank.rotationSpeed - RotationSpeedUpAmount;
        Invoke("IsNormal", SpeedDownTime);
        TakenBoost = true;
    }
    private void IsNormal()
    {
        tank.maxVelocity = OriginalSpeed;
        tank.rotationSpeed = OriginalRotationSpeed;
        TakenBoost = false;
    }
    


    private void ShootNormal()
    {
        startShootNormalCooldown = false;
        TakenBoost = false;
        bomb = false;
        burstFire = false;
        laserFire = false;
        flameFire = false;
        homingFire = false;
    }


    private void  Bomb()
    {
        bomb = true;
        TakenBoost = true;
    }

    
    private void Burst()
    {
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

    private void HomingMissile()
    {
        homingFire = true;
        TakenBoost = true;
    }





    private void delayCooldown()
    {
        if (burstFire)
        {
            if(BurstTime <= 0)
            {
                ShootNormal();
                BurstTime = 10f;
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

        if (flameFire)
        {
            if (tank.ButtonShoot)
            {
                FlameTimer -= Time.deltaTime;
                if (FlameTimer <= 0)
                {
                    ShootNormal();
                    FlameTimer = 10f;
                }
            }
        }

        if (homingFire)
        {
            if (tank.ButtonShoot)
            {
                ShootNormal();
            }
        }

    }
}
