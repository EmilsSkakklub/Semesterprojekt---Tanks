using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowBlueScore : MonoBehaviour
{
    public Score score;
    public Text TextScoreBlue;
    void Awake()
    {
        score = GameObject.Find("Score").GetComponent<Score>();
    }

    void Start()
    {
        gameObject.SetActive(false);
    }
    private void Update() {
        TextScoreBlue.text = score.blueScore.ToString();
    }
}
