using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideWithBullet : MonoBehaviour
{
    public Skydder skydder;
    public ScreenShakeController ssc;
    // Start is called before the first frame update
    private void Update() {
        if (GameObject.Find("BigBoy(Clone)") != null) {
            skydder.BigBoyInAir = true;
        } else {
            skydder.BigBoyInAir = false;
        } 
           
    }
    private void OnCollisionEnter2D (Collision2D other) {
        if(other.gameObject.tag == "Bullet") {
            ssc.StartShake(ssc.length, ssc.power);
        }
        else if(other.gameObject.tag == "Bomb") {
            ssc.StartShake(ssc.bigLength, ssc.bigPower);
        }
        else if(other.gameObject.tag == "HomingMissile") {
            ssc.StartShake(ssc.mediumLengh, ssc.mediumPower);
        }

    }
}
