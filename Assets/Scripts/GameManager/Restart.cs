using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart : MonoBehaviour {
    public PlayerHitPoints playerHP;
    public PlayerHitPoints2 playerHP2;

    public Score score;
    public MapChange mc;
    private bool PleaseDoThisOnce = true;

    public float GameResetTimer = 5f;

    private void Start() {
        score = GameObject.Find("Score").GetComponent<Score>();
        mc    = GameObject.Find("MapChanger").GetComponent<MapChange>();
    }
    void Update() {
        RestartManually();
        DeathRestart();
        
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            SceneManager.LoadScene("Map1");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            SceneManager.LoadScene("Map2");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) {
            SceneManager.LoadScene("Map3");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4)) {
            SceneManager.LoadScene("Map4");
        }
        if (Input.GetKeyDown(KeyCode.Alpha5)) {
            SceneManager.LoadScene("Map5");
        }
        if (Input.GetKeyDown(KeyCode.Alpha6)) {
            SceneManager.LoadScene("Map6");
        }
        if (Input.GetKeyDown(KeyCode.Alpha7)) {
            SceneManager.LoadScene("Map7");
        }
        if (Input.GetKeyDown(KeyCode.Alpha8)) {
            SceneManager.LoadScene("Map8");
        }
        if (Input.GetKeyDown(KeyCode.Alpha9)) {
            SceneManager.LoadScene("Map9");
        }
    }
    public void DeathRestart() {

        if (playerHP.PlayerHp == 0  || playerHP2.PlayerHp == 0 ) {
            if (score.blueScore != score.scoreMax || score.pinkScore != score.scoreMax) {
                PleaseDoThisOnce = true;
                Invoke("LoadRandomMap", GameResetTimer);
            }
            if(score.blueScore == score.scoreMax || score.pinkScore == score.scoreMax) {
                Invoke("LoadStartMenu", GameResetTimer);
            }
            
        } 
    }
    public void RestartManually() {
        if (Input.GetKeyDown(KeyCode.R)) {
            Invoke("RestartGame", 0f);
        }
    }
     
    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void LoadStartMenu() {
        SceneManager.LoadScene("Start");
    }
    public void LoadRandomMap() {
        if (PleaseDoThisOnce) {
            mc.LoadRandomMap();
            PleaseDoThisOnce = false;
        }
    }
}

