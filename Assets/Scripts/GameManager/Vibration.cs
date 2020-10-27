using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vibration : MonoBehaviour
{
    public float delta = 0.000001f;  // Amount to move left and right from the start point
    public float speed = 5;
    private Vector3 startPos;
    // Update is called once per frame
    void Start() {
        startPos = transform.position;
    }
    void Update()
    {
        {
            Vector3 v = startPos;
            v.x += delta * Mathf.Sin(Time.time * speed);
            transform.position = v;
        }
    }
}
