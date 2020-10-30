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

    public PlayerHitPoints php;
    public PlayerHitPoints2 php2;
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
        if (score.pinkScore == score.scoreMax) { //WINS
            Debug.Log("show win");
            pinkWin.gameObject.SetActive(true);
        }
    }
    void ShowScoreBlue() {
        if (php2.PlayerHp <= 0) {
            sbs.gameObject.SetActive(true);
            sps.gameObject.SetActive(true);// numbers
        }
        if (score.blueScore == score.scoreMax) { //WINS
            Debug.Log("show win");
            blueWin.gameObject.SetActive(true);

        }
    }
}
