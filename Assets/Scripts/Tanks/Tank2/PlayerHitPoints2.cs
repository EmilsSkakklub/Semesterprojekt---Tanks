using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitPoints2 : MonoBehaviour {

    public GameObject Player2;
    public PlayerMovement2 pm;
    public Skydder2 skydder;
    public Score score;
    public ParticleSystem ps;

    public HealthBar hpBar;

    public int PlayerHp = 3;
    public int BulletDmg = 1;
    public int BombDmg = 3;
    public int explosionDmg = 2;
    public int laserDamage = 1;

    private void Start() {
        score = GameObject.Find("Score").GetComponent<Score>();

        hpBar.setMaxHealth(PlayerHp);
    }
    void Update() 
    {
        hpBar.updateHealth(PlayerHp);

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
        else if (collision.gameObject.tag == "Explosion")
        {
            pm.stunned = true;
            PlayerHp = PlayerHp - explosionDmg;
        }

    }


}





