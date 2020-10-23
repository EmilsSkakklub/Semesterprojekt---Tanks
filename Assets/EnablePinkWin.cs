using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablePinkWin : MonoBehaviour {
    public PlayerHitPoints2 BlueHP;
    void Start() {
        gameObject.SetActive(false);
    }
}
