using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sp1 : MonoBehaviour
{
    public Boxspawner bs;
    public bool SpawnAvaliable1 = true;

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
            other.gameObject.tag == "Laser") {
            Debug.Log("SP1 TAKEN");
            SpawnAvaliable1 = false;
            bs.stopRemoving1 = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Box" ||
            other.gameObject.tag == "BombUp" ||
            other.gameObject.tag == "Burst" ||
            other.gameObject.tag == "FlamePickUp" ||
            other.gameObject.tag == "HomingMissile" ||
            other.gameObject.tag == "Laser") {
            Debug.Log("SP1 FREE");
            SpawnAvaliable1 = true;
            bs.stopAdding1 = false;
        }
    }
}
