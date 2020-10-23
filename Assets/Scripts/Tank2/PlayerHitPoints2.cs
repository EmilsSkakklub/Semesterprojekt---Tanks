using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitPoints2 : MonoBehaviour {

    public GameObject Player2;
    public Skydder2 skydder;
    public EnablePinkWin pinkWin;

    public float PlayerHp = 3f;
    public float BulletDmg = 1f;
    public float BombDmg = 3f;


    void Update() 
    {
        if (PlayerHp <= 0) 
        {
            skydder.BigBoyInAir = false;
            pinkWin.gameObject.SetActive(true);
            Player2.SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Bullet") {
            PlayerHp = PlayerHp - BulletDmg;
        }
        else if (other.gameObject.tag == "Bomb") {
            PlayerHp = PlayerHp - BombDmg;
        }
    }

}
