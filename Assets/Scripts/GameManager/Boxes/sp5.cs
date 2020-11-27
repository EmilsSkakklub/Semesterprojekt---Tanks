using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sp5 : MonoBehaviour
{
    public Boxspawner bs;
    public bool SpawnAvaliable5 = true;

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
            Debug.Log("SP5 TAKEN");
            SpawnAvaliable5 = false;
            bs.stopRemoving5 = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Box" ||
            other.gameObject.tag == "BombUp" ||
            other.gameObject.tag == "Burst" ||
            other.gameObject.tag == "FlamePickUp" ||
            other.gameObject.tag == "HomingMissile" ||
            other.gameObject.tag == "Laser" ) {
            Debug.Log("SP5 FREE");
            SpawnAvaliable5 = true;
            bs.stopAdding5 = false;
        }
    }
}
