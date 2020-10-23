using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableBlueWin : MonoBehaviour
{
    public PlayerHitPoints PinkHP;
    void Start()
    {
        gameObject.SetActive(false);
    }
}
