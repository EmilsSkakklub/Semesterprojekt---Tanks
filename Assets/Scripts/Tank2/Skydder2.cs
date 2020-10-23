using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Skydder2 : MonoBehaviour {
    public ScreenShakeController ssc;

    public GameObject Projectile;
    public GameObject BigBoy;
    public PickUp2 pu;
    public PlayerMovement2 pm;


    public float projectileSpeed = 500;
    public float BigBoySpeed = 300;

    public bool BigBoyInAir = false;

    public bool onCoolDown = false;
    public float coolDownTime = 1;


    void Update() {
        if (pm.ButtonShoot && !onCoolDown) {
            Fire();
            ssc.StartShake(ssc.length, ssc.power);
        }

        if (BigBoyInAir == true) {
            ssc.StartShake(ssc.length, ssc.power);
        }
    }
    void Fire() {
        if (pu.Bombs > 0) {
            GameObject bomb = Instantiate(BigBoy, transform.position, gameObject.transform.rotation) as GameObject;

            bomb.GetComponent<Rigidbody2D>().AddForce(transform.up * BigBoySpeed);
            onCoolDown = true;
            Invoke("coolDown", coolDownTime);
            pu.Bombs--;
        } else {
            GameObject bullet = Instantiate(Projectile, transform.position, gameObject.transform.rotation) as GameObject;

            bullet.GetComponent<Rigidbody2D>().AddForce(transform.up * projectileSpeed);
            onCoolDown = true;
            Invoke("coolDown", coolDownTime);
        }

    }
    private void coolDown() {
        onCoolDown = false;
    }

}
