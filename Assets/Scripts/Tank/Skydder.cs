using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Skydder : MonoBehaviour {
    public ScreenShakeController ssc;

    public GameObject Projectile;
    public GameObject BigBoy;
    public PickUp pu;
    public PlayerMovement pm;


    public float projectileSpeed = 500f;
    public float BigBoySpeed = 300f;

    public bool BigBoyInAir = false;

    public bool onCoolDown = false;
    public float coolDownTime = 0.3f;
    public float coolDownTimeBurst = 1f;



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
    }
    void Fire() {
        //nuke
        if(pu.Bombs > 0) {
            GameObject bomb = Instantiate(BigBoy, transform.position, gameObject.transform.rotation) as GameObject;
            bomb.GetComponent<Rigidbody2D>().AddForce(transform.up * BigBoySpeed);

            onCoolDown = true;
            Invoke("coolDown", coolDownTime);
            pu.Bombs--;
        }
        //burst
        else if (pu.burstFire)
        {
            Invoke("spawnBullet", 0.0f);
            Invoke("spawnBullet", 0.1f);
            Invoke("spawnBullet", 0.2f);
            Invoke("spawnBullet", 0.3f);
            Invoke("spawnBullet", 0.4f);
            onCoolDown = true;
            Invoke("coolDown", coolDownTimeBurst);

        }
        //shotgun 
        else if (pu.shotgunFire)
        {
            //some code LOL
        }
        //shooting noramlly
        else {
            spawnBullet();
            onCoolDown = true;
            Invoke("coolDown", coolDownTime);
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
