using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sp6 : MonoBehaviour
{
    public Boxspawner bs;
    public bool SpawnAvaliable6 = true;

    private void Start()
    {
        gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Box") {
            Debug.Log("SP6 TAKEN");
            SpawnAvaliable6 = false;
            bs.stopRemoving6 = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Box") {
            Debug.Log("SP6 FREE");
            SpawnAvaliable6 = true;
            bs.stopAdding6 = false;
        }
    }
}
