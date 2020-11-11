using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.Mathematics;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.UIElements;

public class Skydder : MonoBehaviour {
    public ScreenShakeController ssc;

    public GameObject Projectile;
    public GameObject BigBoy;
    public PickUp pu;
    public PlayerMovement pm;

    public LineRenderer lr;
    public ParticleSystem laserParticle;
    public GameObject laserCollider;

    public int BurstAmount = 5;

    public float projectileSpeed = 500f;
    public float BigBoySpeed = 300f;

    public bool BigBoyInAir = false;

    public bool onCoolDown = false;
    public float coolDownTime = 0.3f;
    public float coolDownTimeBurst = 1f;

    //laser variables
    public bool takeDamageByLaser = false;
    public float damageTimer = 0.5f;
    private float resetDamageTimer;



    private void Start()
    {
        resetDamageTimer = damageTimer;
    }

    void Update() {
        //if pressing the shoot button ->> SHOOT
        if (pm.ButtonShoot && !onCoolDown) {
            Fire();
            ssc.StartShake(ssc.length,ssc.power);
        }
        //while the big boy nuke is in the air, shake the screen
        if (BigBoyInAir == true) {
            ssc.StartShake(ssc.length, ssc.power);
        }

        //Check if laser should render + shake the screen a little
        checkLaserActive();
    }
    void Fire() {
        //bomb
        if(pu.Bombs > 0) {
            BombMode();
        }


        //burst
        else if (pu.burstFire)
        {
            BurstMode();
        }


        //shotgun 
        else if (pu.shotgunFire)
        {
            ShotgunMode();
        }


        else if (pu.laserFire)
        {
            LaserMode();
        }


        //normal
        else {
            NormalMode();
        }    
    }


    private void NormalMode() {
        spawnBullet();
        onCoolDown = true;
        Invoke("coolDown", coolDownTime);
    }




    private void BombMode() {
        GameObject bomb = Instantiate(BigBoy, transform.position, gameObject.transform.rotation) as GameObject;
        bomb.GetComponent<Rigidbody2D>().AddForce(transform.up* BigBoySpeed);

    onCoolDown = true;
    Invoke("coolDown", coolDownTime);
    pu.Bombs--;
    }


    private void BurstMode() {
        int i = 0;
        float timeBetweenShots = 0;

        while (i < BurstAmount) {
            Invoke("spawnBullet", timeBetweenShots);
            i++;
            timeBetweenShots += 0.1f;
        }

        onCoolDown = true;
        Invoke("coolDown", coolDownTimeBurst);
    }


    private void ShotgunMode() {
        //some shotgun code here
    }

    private void LaserMode()
    {
        lr.SetPosition(0, transform.position);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up);
        Debug.DrawLine(transform.position, hit.point);

        if (hit.collider.tag == "Wall" || hit.collider.tag == "Player" || hit.collider.tag == "Box" || hit.collider.tag == "SpawnPoint")
        {
            lr.SetPosition(1, new Vector3(hit.point.x, hit.point.y, transform.position.z));
            Instantiate(laserParticle, hit.point, quaternion.identity);
            GameObject Lol =  Instantiate(laserCollider, hit.point, quaternion.identity);
        }
        else
        {
            lr.SetPosition(1, transform.up * 2000);
        }
    }


    private void checkLaserActive()
    {
        if(pm.ButtonShoot && pu.laserFire)
        {
            ssc.StartShake(0.02f, 0.02f);
            lr.enabled = true;
        }
        else
        {
            lr.enabled = false;
        }

        //cooldown for player taking damage by laser
        if (takeDamageByLaser)
            {
            if (damageTimer > 0)
            {
                damageTimer -= Time.deltaTime;
                if (damageTimer <= 0)
                {
                    takeDamageByLaser = false;
                    damageTimer = resetDamageTimer;
                }
            }
        }
        
    }
        







    //shooting cooldown
    private void coolDown(){
        onCoolDown = false;
    }

    //spawn a bullet, and give it a velocity and direction
    private void spawnBullet()
    {
        GameObject bullet = Instantiate(Projectile, transform.position, gameObject.transform.rotation) as GameObject;
        bullet.GetComponent<Rigidbody2D>().AddForce(transform.up * projectileSpeed);
    }

}
