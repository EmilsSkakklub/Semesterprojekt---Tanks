using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerHitPoints : MonoBehaviour

{
    public GameObject Player1;
    public Skydder skydder;
    public Score score;
    public ParticleSystem ps;

    public int PlayerHp = 3;
    public int BulletDmg = 1;
    public int BombDmg = 3;
    public int laserDamage = 1;


    private void Start() {
        score = GameObject.Find("Score").GetComponent<Score>();
    }
    void Update()
    {

        if (PlayerHp <= 0) 
        {
            skydder.BigBoyInAir = false;
            score.blueScore++;
            Player1.SetActive(false);
            Instantiate(ps, transform.position, quaternion.identity);
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
