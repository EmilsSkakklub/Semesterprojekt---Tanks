using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowScores : MonoBehaviour
{
    public EnablePinkWin pinkWin;
    public EnableBlueWin blueWin;
    public ShowBlueScore sbs;
    public ShowPinkScore sps;
    public Score score;
    public AudioSource BlueWinsSound;
    public AudioSource PinkWinsSound;

    public PlayerHitPoints php;
    public PlayerHitPoints2 php2;

    private bool alreadyPlayed = false;
    private bool alreadyPlayed2 = false;
    private void Start() {
        score = GameObject.Find("Score").GetComponent<Score>();
    }
    void Update()
    {
        ShowScorePink();
        ShowScoreBlue();
    }
    void ShowScorePink() {
        if (php.PlayerHp <= 0) {
            sps.gameObject.SetActive(true);
            sbs.gameObject.SetActive(true);
        }
        if (score.pinkScore == score.scoreMax) { // PINK WINS
            if (!alreadyPlayed) {
                alreadyPlayed = true;
                PinkWinsSound.PlayDelayed(0.5f);
            }
            pinkWin.gameObject.SetActive(true);
        }
    }
    void ShowScoreBlue() {
        if (php2.PlayerHp <= 0) {
            sbs.gameObject.SetActive(true);
            sps.gameObject.SetActive(true);// numbers
        }
        if (score.blueScore == score.scoreMax) { // BLUE WINS

            if (!alreadyPlayed2) {
                alreadyPlayed2 = true;
                BlueWinsSound.PlayDelayed(0.5f);
            }
            blueWin.gameObject.SetActive(true);


        }
    }
}
