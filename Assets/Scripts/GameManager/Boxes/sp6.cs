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
        if (other.gameObject.tag == "Box" ||
            other.gameObject.tag == "BombUp" ||
            other.gameObject.tag == "Burst" ||
            other.gameObject.tag == "FlamePickUp" ||
            other.gameObject.tag == "HomingMissile" ||
            other.gameObject.tag == "Laser") {
            Debug.Log("SP6 TAKEN");
            SpawnAvaliable6 = false;
            bs.stopRemoving6 = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Box" ||
            other.gameObject.tag == "BombUp" ||
            other.gameObject.tag == "Burst" ||
            other.gameObject.tag == "FlamePickUp" ||
            other.gameObject.tag == "HomingMissile" ||
            other.gameObject.tag == "Laser") {
            Debug.Log("SP6 FREE");
            SpawnAvaliable6 = true;
            bs.stopAdding6 = false;
        }
    }
}
