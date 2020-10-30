using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {
    public int pinkScore = 0;
    public int blueScore = 0;
    public int scoreMax = 3;
    void Awake() {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Score");

        if (objs.Length > 1) {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);

    }
    private void Update() {
        if (pinkScore == scoreMax || blueScore == scoreMax) {
            Invoke("ScoreReset", 5);
            
        }
    }
    void ScoreReset() {
        pinkScore = 0;
        blueScore = 0;
    }
}
