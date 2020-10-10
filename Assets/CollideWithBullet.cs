using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideWithBullet : MonoBehaviour
{
    public ScreenShakeController ssc;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Bullet") {
            ssc.StartShake(ssc.length, ssc.power);
        }
    }
}
