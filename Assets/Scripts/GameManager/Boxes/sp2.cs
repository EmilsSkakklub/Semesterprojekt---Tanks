using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sp2 : MonoBehaviour
{
    public Boxspawner bs;
    public bool SpawnAvaliable2 = true;

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
            Debug.Log("SP2 TAKEN");
            SpawnAvaliable2 = false;
            bs.stopRemoving2 = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Box" ||
            other.gameObject.tag == "BombUp" ||
            other.gameObject.tag == "Burst" ||
            other.gameObject.tag == "FlamePickUp" ||
            other.gameObject.tag == "HomingMissile" ||
            other.gameObject.tag == "Laser" ){
            Debug.Log("SP2 FREE");
            SpawnAvaliable2 = true;
            bs.stopAdding2 = false;
        }
    }
}
