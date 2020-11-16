using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerHitPoints : MonoBehaviour

{
    public GameObject Player1;
    public PlayerMovement pm;
    public Skydder skydder;
    public Score score;
    public ParticleSystem ps;
    private Transform body;

    private HealthBarPink hpBar;

    public int PlayerHp = 100;
    public int BulletDmg = 3;
    public int BombDmg = 30;
    public int explosionDmg = 15;
    public int laserDamage = 1;


    private void Start() {
        score = GameObject.Find("Score").GetComponent<Score>();
        hpBar = GameObject.Find("Player1").GetComponentInChildren<HealthBarPink>();
        body = GameObject.Find("Body").GetComponent<Transform>();


        hpBar.setMaxHealth(PlayerHp);
    }
    void Update()
    {
        hpBar.updateHealth(PlayerHp);
        hpBar.transform.rotation = quaternion.Euler(0, 0, 0);
        hpBar.transform.position = new Vector3(body.transform.position.x, body.transform.position.y - 1.2f, body.transform.position.y);

        if(PlayerHp < 0)
        {
            PlayerHp = 0;
        }

        if (PlayerHp == 0) 
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
        else if (collision.gameObject.tag == "Explosion")
        {
            pm.stunned = true;
            PlayerHp = PlayerHp - explosionDmg;
        }
    }





}
