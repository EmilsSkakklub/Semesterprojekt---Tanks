using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPinkScore : MonoBehaviour
{
    public Score score;
    public Text TextScorePink;
    void Awake()
    {
        score = GameObject.Find("Score").GetComponent<Score>();
    }
    private void Start() {
       gameObject.SetActive(false);
    }
    private void Update() {
        TextScorePink.text = score.pinkScore.ToString();
    }
}
