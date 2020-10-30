using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitPoints : MonoBehaviour

{
    public GameObject Player1;
    public Skydder skydder;
    public EnableBlueWin blueWin;
    public ShowBlueScore sbs;
    public Score score;

    public float PlayerHp = 3f;
    public float BulletDmg = 1f;
    public float BombDmg = 3f;

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
