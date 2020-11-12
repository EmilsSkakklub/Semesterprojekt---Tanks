using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MapChange : MonoBehaviour
{
    public List<int> LevelsToPlay = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    void Awake() {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("MapChange");

        if (objs.Length > 1) {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);    

    }
    private void Update() {
        if (LevelsToPlay.Count == 0) {
            LevelsToPlay.Add(1);
            LevelsToPlay.Add(2);
            LevelsToPlay.Add(3);
            LevelsToPlay.Add(4);
            LevelsToPlay.Add(5);
            LevelsToPlay.Add(6);
            LevelsToPlay.Add(7);
            LevelsToPlay.Add(8);
            LevelsToPlay.Add(9);

        }
    }
    public void LoadRandomMap() {
        //choose the index of a level:
        int nextLevelIndex = Random.Range(0, LevelsToPlay.Count);
        //get the actual sceneIndex by the index of our list:
        int nextLevel = LevelsToPlay[nextLevelIndex];
        //remove the sceneIndex from the list to make it not appear again:
        LevelsToPlay.Remove(nextLevel);
        // load the level:
        SceneManager.LoadScene(nextLevel);
    }

}
