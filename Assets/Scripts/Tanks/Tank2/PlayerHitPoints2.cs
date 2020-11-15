using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerHitPoints2 : MonoBehaviour {

    public GameObject Player2;
    public PlayerMovement2 pm;
    public Skydder2 skydder;
    public Score score;
    public ParticleSystem ps;
    private Transform body;

    private HealthBarBlue hpBar;


    public int PlayerHp = 100;
    public int BulletDmg = 3;
    public int BombDmg = 30;
    public int explosionDmg = 15;
    public int laserDamage = 1;

    private void Start() {
        score = GameObject.Find("Score").GetComponent<Score>();
        hpBar = GameObject.Find("Player2").GetComponentInChildren<HealthBarBlue>();
        body = GameObject.Find("Body2").GetComponent<Transform>();

        hpBar.setMaxHealth(PlayerHp);
    }
    void Update() 
    {
        hpBar.updateHealth(PlayerHp);
        hpBar.transform.rotation = Quaternion.Euler(0,0,0);
        hpBar.transform.position = new Vector3(body.transform.position.x, body.transform.position.y - 1.2f, body.transform.position.z);

        if(PlayerHp < 0)
        {
            PlayerHp = 0;
        }

        if (PlayerHp == 0) 
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





