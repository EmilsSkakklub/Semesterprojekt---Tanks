using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitPoints2 : MonoBehaviour {

    public GameObject Player2;
    public Skydder2 skydder;
    public EnablePinkWin pinkWin;
    public ShowPinkScore sps;
    public Score score;
    public ParticleSystem ps;

    public float PlayerHp = 3f;
    public float BulletDmg = 1f;
    public float BombDmg = 3f;
    public float laserDamage = 1f;

    private void Start() {
        score = GameObject.Find("Score").GetComponent<Score>();
    }
    void Update() 
    {


        if (PlayerHp <= 0) 
        {
            skydder.BigBoyInAir = false;
            score.pinkScore++;
            Instantiate(ps, transform.position, Quaternion.identity);
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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "LaserCollider")
        {
            if (!skydder.takeDamageByLaser)
            {
                skydder.takeDamageByLaser = true;
                PlayerHp -= laserDamage;
            }
        }
    }


}





