using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Skydder : MonoBehaviour {
    public ScreenShakeController ssc;

    public GameObject Projectile;
    public float attackSpeed = 0.5f;
    public float projectileSpeed = 500;

    public bool onCoolDown = false;
    public float coolDownTime = 1;


    void Update() {
        if (Input.GetKey(KeyCode.Q) && !onCoolDown) {
            Fire();
            ssc.StartShake(ssc.length,ssc.power);
        }


    }
    void Fire() {
        GameObject bullet = Instantiate(Projectile, transform.position, gameObject.transform.rotation) as GameObject;

        bullet.GetComponent<Rigidbody2D>().AddForce(transform.up * projectileSpeed);
        onCoolDown = true;
        Invoke("coolDown", coolDownTime);
    }
    private void coolDown(){
        onCoolDown = false;
    }
    
}
