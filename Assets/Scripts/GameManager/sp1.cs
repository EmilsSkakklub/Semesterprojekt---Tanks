using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sp1 : MonoBehaviour
{
    public Boxspawner bs;
    public bool SpawnAvaliable1 = true;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Box") {
            Debug.Log("SP1 TAKEN");
            SpawnAvaliable1 = false;
            bs.stopRemoving1 = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Box") {
            Debug.Log("SP1 FREE");
            SpawnAvaliable1 = true;
            bs.stopAdding1 = false;
        }
    }
}
