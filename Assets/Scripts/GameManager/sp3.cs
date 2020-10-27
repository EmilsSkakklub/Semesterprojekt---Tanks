using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sp3 : MonoBehaviour
{
    public Boxspawner bs;
    public bool SpawnAvaliable3 = true;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Box") {
            Debug.Log("SP3 TAKEN");
            SpawnAvaliable3 = false;
            bs.stopRemoving3 = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Box") {
            Debug.Log("SP3 FREE");
            SpawnAvaliable3 = true;
            bs.stopAdding3 = false;
        }
    }
}
