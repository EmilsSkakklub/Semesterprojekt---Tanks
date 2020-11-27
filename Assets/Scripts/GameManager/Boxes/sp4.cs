using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sp4 : MonoBehaviour
{
    public Boxspawner bs;
    public bool SpawnAvaliable4 = true;

    private void Start()
    {
        gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Box" ||
            other.gameObject.tag == "BombUp" ||
            other.gameObject.tag == "Burst" ||
            other.gameObject.tag == "FlamePickUp" ||
            other.gameObject.tag == "HomingMissile" ||
            other.gameObject.tag == "Laser" ) {
            Debug.Log("SP4 TAKEN");
            SpawnAvaliable4 = false;
            bs.stopRemoving4 = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Box" ||
            other.gameObject.tag == "BombUp" ||
            other.gameObject.tag == "Burst" ||
            other.gameObject.tag == "FlamePickUp" ||
            other.gameObject.tag == "HomingMissile" ||
            other.gameObject.tag == "Laser") {
            Debug.Log("SP4 FREE");
            SpawnAvaliable4 = true;
            bs.stopAdding4 = false;
        }
    }
}
