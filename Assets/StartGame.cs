using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public MapChange mc;

    private void Start() {
        mc = GameObject.Find("MapChanger").GetComponent<MapChange>();
    }
    void OnMouseDown() {
        mc.LoadRandomMap();
    }

}
