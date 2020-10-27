using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart : MonoBehaviour {
    public PlayerHitPoints playerHP;
    public PlayerHitPoints2 playerHP2;

    public Text blueWins;
    public Text pinkWins;

    // Update is called once per frame
    void Update() {
        RestartManually();
        DeathRestart();
    }
    public void DeathRestart() {
        if (playerHP.PlayerHp == 0) {
            Invoke("RestartGame", 5f);
        }
        else if (playerHP2.PlayerHp == 0) {
           
            Invoke("RestartGame", 5f);
        }
    }
    public void RestartManually() {
        if (Input.GetKeyDown(KeyCode.R)) {
            Invoke("RestartGame", 0f);
        }
    }
    public void RestartGame() {
        SceneManager.LoadScene("Map1");
    }
}

