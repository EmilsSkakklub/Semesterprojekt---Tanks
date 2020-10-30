using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordinateChecker : MonoBehaviour
{

    public Transform body;
    void Update()
    {
        gameObject.transform.position = new Vector3(body.position.x, body.position.y, body.position.z);
    }
}
