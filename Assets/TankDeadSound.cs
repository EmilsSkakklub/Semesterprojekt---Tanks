using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankDeadSound : MonoBehaviour {

    private PlayerHitPoints php;
    private PlayerHitPoints2 php2;
    private AudioSource PlayerDead;

    private bool PlayOnce = true;
    private bool PlayOnce2 = true;

    private void Awake() {
        php = GameObject.Find("Player1").GetComponentInChildren<PlayerHitPoints>();
        php2 = GameObject.Find("Player2").GetComponentInChildren<PlayerHitPoints2>();
        PlayerDead = GetComponent<AudioSource>();
    }
    void Update() {
        if (php.PlayerHp <= 0) {
            if (PlayOnce) {
                PlayOnce = false;
                PlayerDead.Play();
            }
        }

        if (php2.PlayerHp <= 0) {
            if (PlayOnce2) {
                PlayOnce2 = false;
                PlayerDead.Play();
            }
        }
    }
}
