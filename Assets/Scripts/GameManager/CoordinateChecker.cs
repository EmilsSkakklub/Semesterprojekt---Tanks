using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordinateChecker : MonoBehaviour
{

    public Transform body;


    private void Start()
    {
        body = GameObject.Find("Body").GetComponentInChildren<Transform>();
    }
    void Update()
    {
        gameObject.transform.position = new Vector3(body.position.x, body.position.y, body.position.z);
    }
}
