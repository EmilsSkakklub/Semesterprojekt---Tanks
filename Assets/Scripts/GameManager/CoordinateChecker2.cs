using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordinateChecker2 : MonoBehaviour
{
    public Transform body2;
    void Update() {
        gameObject.transform.position = new Vector3(body2.position.x, body2.position.y, body2.position.z);
    }
}
